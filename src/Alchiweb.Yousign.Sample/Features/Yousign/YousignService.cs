using System.Text;
using System.Text.Json;
using Alchiweb.Yousign.Sample.Core.Features.Yousign;
using Alchiweb.Yousign.Sample.Domain;
using Alchiweb.Yousign.Sample.Domain.Enums;
using Alchiweb.Yousign.Sample.Infrastructure.Services;
using Ardalis.Specification.EntityFrameworkCore.SharedKernel;

namespace Alchiweb.Yousign.Sample.Features.Yousign;

public class YousignService : IYousignService
{
    private const string ALCHIWEB_WEBHOOK_URL = "sample.com/webhook/yousign";
    
    protected readonly IRepository<Signature, Guid> _signatureRepository;
    protected readonly IRepository<Signer, Guid> _signerRepository;
    protected readonly IRepository<Document, Guid> _documentRepository;
    protected readonly IRepository<Approver, Guid> _approverRepository;
    protected readonly ICryptoService _cryptoService;
    protected readonly ILogger<YousignService> _logger;
    protected readonly DtoMapper _mapper;
    protected readonly JsonSerializerOptions _jsonOptions;

    public YousignService(
        IRepository<Signature, Guid> signatureRepository,
        IRepository<Signer, Guid> signerRepository,
        IRepository<Document, Guid> documentRepository,
        IRepository<Approver, Guid> approverRepository,
        ICryptoService cryptoService,
        ILogger<YousignService> logger,
        DtoMapper mapper,
        JsonSerializerOptions jsonOptions
        )
    {
        _signatureRepository = signatureRepository;
        _signerRepository = signerRepository;
        _documentRepository = documentRepository;
        _approverRepository = approverRepository;
        _cryptoService = cryptoService;
        _logger = logger;
        _mapper = mapper;
        _jsonOptions = jsonOptions;
    }

    public async Task<bool> GetYousignEvent(Alchiweb.Yousign.Webhook.Payload payload, CancellationToken ct = default)
    {
        if (payload.Data?.Signer?.Id != null && payload.Data.Signer.Id != Guid.Empty)
        {
            Signer? signer = null;
            bool creating = false;
            
            try
            {
                signer = await _signerRepository.FirstOrDefaultAsync(new SignerByIdSpec(payload.Data.Signer.Id, SignerWithEnum.Signature), ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error database: 'Get' signer {SignerId} ", payload.Data.Signer.Id);
            }
            if (signer == null)
            {
                creating = true;
                signer = new(payload.Data.Signer.Id);
            }
            signer.Status = _mapper.Map(payload.Data.Signer.Status);

            if (creating)
            {
                _logger.LogError("Error Yousign signer not present in the database: signer {SignerId} ", payload.Data.Signer.Id);
                //try
                //{
                //    await _signerRepository.AddAsync(signer, ct);
                //}
                //catch (Exception ex)
                //{
                //    _logger.LogError(ex, "Error database: 'Add' signer {SignerId} ", signer.Id);
                //}
            }
            else
            {
                try
                {
                    await _signerRepository.UpdateAsync(signer, ct);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error database: 'Update' signer {SignerId} ", signer.Id);
                }
            }

            if (signer.Status == SignerStatusEnum.Signed ||
                signer.Status == SignerStatusEnum.Error ||
                signer.Status == SignerStatusEnum.Declined
                )
            {
                var signerObject = _mapper.Map(signer);
                var signerJson = JsonSerializer.Serialize(signerObject, _jsonOptions);
                var signatureWithTimestamp = _cryptoService.CreateSignature();
                string domain = "";
                if (signer.Signature != null)
                {
                    domain = $"https://{signer.Signature.Domain}{(string.IsNullOrWhiteSpace(signer.Signature.Domain) ? "" : ".")}{ALCHIWEB_WEBHOOK_URL}";
                }
                if (signer.Signature == null || signer.Signature.Domain.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                {
                    using (_logger.BeginScope("Yousign/Signer/localhost"))
                    {
                        _logger.LogWarning("{Domain}", domain);
                        _logger.LogWarning("{SignerJson}", signerJson);
                    }
                }
                else
                {
                    await CallAlchiwebWebhook(signerJson, domain, signatureWithTimestamp, ct);
                }

            }
            return true;
        }


        if (payload.Data?.SignatureRequest?.Id != null && payload.Data.SignatureRequest.Id != Guid.Empty)
        {
            Signature? signature = null;
            bool creating = false;
            try
            {
                signature = await _signatureRepository.GetByIdAsync(payload.Data.SignatureRequest.Id, ct);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error database: 'Get' signature {SignatureId} ", payload.Data.SignatureRequest.Id);
            }
            if (signature == null)
            {
                creating = true;
                signature = new(payload.Data.SignatureRequest.Id);
            }
            if (payload.Data.SignatureRequest.Status != null)
                signature.SignatureStatus = _mapper.Map(payload.Data.SignatureRequest.Status.Value);
            if (payload.Data.SignatureRequest.Name != null)
                signature.Name = payload.Data.SignatureRequest.Name;
            if (payload.Data.SignatureRequest.Sender?.Email != null)
                signature.SenderEmail = payload.Data.SignatureRequest.Sender.Email;
            if (payload.Data.SignatureRequest.IsOrderedSigners != null)
                signature.IsSequential = payload.Data.SignatureRequest.IsOrderedSigners.Value;
            if (payload.Data.SignatureRequest.ExternalId != null)
                signature.ExternalId = payload.Data.SignatureRequest.ExternalId;
            if (payload.Data.SignatureRequest.WorkspaceId != null)
                signature.WorkspaceId = payload.Data.SignatureRequest.WorkspaceId.Value;
            signature.CreatedAt = payload.Data.SignatureRequest.CreatedAt;
            signature.DeletedAt = payload.Data.SignatureRequest.DeletedAt;
            signature.ExpirationDate = payload.Data.SignatureRequest.ExpirationDate;
            try
            {
                signature.LastEventDate = DateTimeOffset.FromUnixTimeSeconds(Int64.Parse(payload.EventTime));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error converting 'EventTime' to unix time seconds {EventTime} ", payload.EventTime);
                signature.LastEventDate = DateTimeOffset.Now;
            }
            if (payload.Data.SignatureRequest.Status == Alchiweb.Yousign.Webhook.Enums.SignatureRequestStatusEnum.Done)
                signature.DoneDate = signature.LastEventDate;

            if (creating)
            {
                try
                {
                    await _signatureRepository.AddAsync(signature, ct);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error database: 'Add' signature {SignatureId} ", signature.Id);
                }
            }
            else
            {
                try
                {
                    await _signatureRepository.UpdateAsync(signature, ct);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error database: 'Update' signature {SignatureId} ", signature.Id);
                }
            }

            // Documents
            var documentsFromSignatureRequest = payload.Data.SignatureRequest.Documents;
            if (documentsFromSignatureRequest != null)
            {
                foreach (var docYousign in documentsFromSignatureRequest)
                {
                    var document = _mapper.Map(docYousign);
                    document.SignatureId = signature.Id;
                    if (document != null)
                    {
                        Document? docExisting = null;
                        try
                        {
                            docExisting = await _documentRepository.GetByIdAsync(document.Id, ct);
                        }
                        catch (Exception ex) {
                            _logger.LogError(ex, "Error database: 'Get' document {DocumentId} ", document.Id);
                        }
                        if (docExisting == null)
                        {
                            try
                            {
                                await _documentRepository.AddAsync(document, ct);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Error database: 'Add' document {DocumentId} ", document.Id);
                            }
                        }
                        else
                        {
                            try
                            {
                                await _documentRepository.UpdateAsync(document, ct);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Error database: 'Update' document {DocumentId} ", document.Id);
                            }
                        }
                    }
                }
            }
            // Approvers
            var approversFromSignatureRequest = payload.Data.SignatureRequest.Approvers;
            if (approversFromSignatureRequest != null)
            {
                foreach (var approverYousign in approversFromSignatureRequest)
                {
                    if (approverYousign.Info != null)
                    {
                        var approver = _mapper.Map(approverYousign);
                        approver.SignatureId = signature.Id;
                        if (approver != null)
                        {
                            Approver? approverExisting = null;
                            try
                            {
                                approverExisting = await _approverRepository.GetByIdAsync(approver.Id, ct);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Error database: 'Get' approver {ApproverId} ", approver.Id);
                            }
                            if (approverExisting == null)
                            {
                                try
                                {
                                    await _approverRepository.AddAsync(approver, ct);
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogError(ex, "Error database: 'Add' approver {ApproverId} ", approver.Id);
                                }
                            }
                            else
                            {
                                try
                                {
                                    await _approverRepository.UpdateAsync(approver, ct);
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogError(ex, "Error database: 'Update' approver {ApproverId} ", approver.Id);
                                }
                            }
                        }
                    }
                }
            }
            // Signers
            var signersFromSignatureRequest = payload.Data.SignatureRequest.Signers;
            if (signersFromSignatureRequest != null)
            {
                foreach (var signerYousign in signersFromSignatureRequest)
                {
                    var signer = _mapper.Map(signerYousign);
                    signer.SignatureId = signature.Id;
                    if (signer != null)
                    {
                        Signer? signerExisting = null;
                        try
                        {
                            signerExisting = await _signerRepository.GetByIdAsync(signer.Id, ct);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Error database: 'Get' signer {SignerId} ", signer.Id);
                        }
                        if (signerExisting == null)
                        {
                            try
                            {
                                await _signerRepository.AddAsync(signer, ct);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Error database: 'Add' signer {SignerId} ", signer.Id);
                            }
                        }
                        else
                        {
                            try
                            {
                                await _signerRepository.UpdateAsync(signer, ct);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Error database: 'Update' signer {SignerId} ", signer.Id);
                            }
                        }
                    }
                }
            }
            if (signature.SignatureStatus == SignatureStatusEnum.Draft ||
                signature.SignatureStatus == SignatureStatusEnum.OnGoing ||
                signature.SignatureStatus == SignatureStatusEnum.Done ||
                signature.SignatureStatus == SignatureStatusEnum.Deleted ||
                signature.SignatureStatus == SignatureStatusEnum.Declined ||
                signature.SignatureStatus == SignatureStatusEnum.Canceled ||
                signature.SignatureStatus == SignatureStatusEnum.Expired
                )
            {
                if (documentsFromSignatureRequest != null && documentsFromSignatureRequest.Length > 0)
                {
                    documentsFromSignatureRequest.ToList().ForEach(s => signature.Documents.Add(_mapper.Map(s)));
                }
                if (approversFromSignatureRequest != null && approversFromSignatureRequest.Length > 0)
                {
                    approversFromSignatureRequest.ToList().ForEach(s => signature.Approvers.Add(_mapper.Map(s)));
                }
                if (signersFromSignatureRequest != null && signersFromSignatureRequest.Length > 0)
                {
                    signersFromSignatureRequest.ToList().ForEach(s => signature.Signers.Add(_mapper.Map(s)));
                }

                var signatureObject = _mapper.Map(signature);
                var signatureJson = JsonSerializer.Serialize(signatureObject, _jsonOptions);
                var signatureWithTimestamp = _cryptoService.CreateSignature();
                string domain = $"https://{signature.Domain}{(string.IsNullOrWhiteSpace(signature.Domain) ? "" : ".")}{ALCHIWEB_WEBHOOK_URL}";
                if (signature.Domain.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                {
                    using (_logger.BeginScope("Yousign/Signature/localhost"))
                    {
                        _logger.LogWarning("{AlchiwebAppDomain}", domain);
                        _logger.LogWarning("{SignatureJson}", signatureJson);
                    }
                }
                else
                {
                    await CallAlchiwebWebhook(signatureJson, domain, signatureWithTimestamp, ct);
                    /*
                    var with = SignatureDtoWithEnum.All;
                    //var filter = UrlEncoder.Create().Encode(@"{""SearchApproverFilters"":[],""DomainFilters"":[],""NameFilters"":[{"c":2,"s":"sign","o":true],""SenderEmailFilters"":[],""StatusFilters"":[],""LastEventDateFilters"":[],""o"":{},""p"":1,""s"":10}");
                    var filterDto = new SignatureDtoFilter();//sorting: SignatureFieldDtoEnum.SignatureStatus, page: 2, pageSize: 15);
                    //filterDto.NameFilters.Add(new(StringFieldFilterEnum.Contains, "sign", true));
                    var filterText = JsonSerializer.Serialize(filterDto);
                    // filterText -> {"signer":[],"domain":[],"name":[{"c":2,"s":"sign","o":true}],"senderEmail":[],"status":[],"date":[],"o":{"SignatureStatus":{"p":0,"r":false}},"p":2,"s":15}
                    var filter = Uri.EscapeDataString(filterText);
                    var response = await httpclient.GetAsync($"http://localhost:5223/api/signature/?with={with}&filter={filter}", ct);
                    //var responseContent = await response.Content.ReadFromJsonAsync<ApiResponse<PagedList<SignatureDto>>>(ct);
                    var responseContent = await response.Content.ReadAsStringAsync(ct);
                    */
                }
            }
            return true;
        }
        return false;
    }

    private async Task CallAlchiwebWebhook(string json, string domain, (string signature, string timestamp) signatureWithTimestamp, CancellationToken ct)
    {
        using var httpclient = new HttpClient();
        httpclient.DefaultRequestHeaders.Add(ICryptoService.SIGNATURE_HEADER, signatureWithTimestamp.signature);
        httpclient.DefaultRequestHeaders.Add(ICryptoService.TIMESTAMP_HEADER, signatureWithTimestamp.timestamp);
        try
        {
            HttpContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            await httpclient.PostAsync($"{domain}", requestContent, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error call Alchiweb Wehook: Post {AlchiwebUrl} {Json}", domain, json);
        }
    }
}
