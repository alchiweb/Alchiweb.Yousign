using AlchiwebApp.Core;
using AlchiwebApp.PagingFiltering.Paging;
using AlchiwebApp.Server.Core;
using Alchiweb.Yousign.Sample.Core.Features.Yousign;
using Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;
using Alchiweb.Yousign.Sample.Domain;
using Ardalis.Specification.EntityFrameworkCore.SharedKernel;

namespace Alchiweb.Yousign.Sample.Features.Yousign;

public class SignatureService : ServerApiServiceBase<Signature, SignatureDto, Guid, SignatureService>, ISignatureService
{
    protected readonly IRepository<Signature, Guid> _signatureRepository;
    protected readonly IRepository<Document, Guid> _documentRepository;
    protected readonly IRepository<Approver, Guid> _approverRepository;
    protected readonly DtoMapper _mapper;
    public SignatureService(
        IRepository<Signature, Guid> signatureRepository,
        IRepository<Document, Guid> documentRepository,
        IRepository<Approver, Guid> approverRepository,
        ILogger<SignatureService> logger,
        DtoMapper mapper
        ) : base(signatureRepository, logger)
    {
        _signatureRepository = signatureRepository;
        _documentRepository = documentRepository;
        _approverRepository = approverRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<PagedList<SignatureDto>>> List(SignatureDtoFilter filter, SignatureDtoWithEnum with, CancellationToken ct = default)
        => await ListGeneric<SignatureDto>(filter, new SignatureByFilterSpec(_mapper.Map(filter), _mapper.Map(with)), ct);

    public async Task<ApiResponse<SignatureDto>> GetById(Guid id, SignatureDtoWithEnum with, CancellationToken ct = default)
    //=> await GetByIdGeneric<SignatureDto>(id, new SignatureByIdSpec(id, _mapper.Map(with)), ct);
    => await FirstGeneric<SignatureDto>(new SignatureByIdSpec(id, _mapper.Map(with)), ct);

    public async Task<ApiResponse<SignatureDto>> Create(SignatureRequest? request, CancellationToken ct = default)
        => await CreateGeneric(request, ct);

    public async Task<ApiResponse<SignatureDto>> Update(SignatureRequest request, CancellationToken ct = default)
        => await UpdateGeneric(request.Id, request, ct);

    public async Task<ApiResponse> Delete(Guid id, CancellationToken ct = default)
        => await DeleteGeneric(id, ct);

    public override Func<Signature, TResult>? GetMapToDtoMethod<TResult>()
    {
        switch (typeof(TResult))
        {
            default:
                var mapToDto = delegate (Signature y) { return _mapper.Map(y); };
                return mapToDto as Func<Signature, TResult>;
        }
    }

    public override Func<TRequest, Signature>? GetMapToEntityMethod<TRequest>()
    {
        switch (typeof(TRequest))
        {
            case Type tRequest when tRequest == typeof(SignatureRequest):
                var mapRequest = delegate (SignatureRequest c) { return _mapper.Map(c); };
                return mapRequest as Func<TRequest, Signature>;
            default:
                return null;
                //var mapToEntity = delegate (SignatureDto y) { return _mapper.Map(y); };
                //return mapToEntity as Func<TRequest, Signature>;
        }
    }
}
