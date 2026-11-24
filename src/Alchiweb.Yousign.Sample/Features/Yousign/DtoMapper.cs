
using AlchiwebApp.PagingFiltering.Paging;
using Alchiweb.Yousign.Sample.Domain;
using Alchiweb.Yousign.Sample.Domain.Enums;
using Alchiweb.Yousign.Sample.Core.Features.Yousign;
using Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;
using Riok.Mapperly.Abstractions;

namespace Alchiweb.Yousign.Sample.Features;

public partial class DtoMapper
{
    public partial SignatureDto Map(Signature entity);
    public partial Signature Map(SignatureRequest request);

    public partial SignerDto Map(Signer entity);
    public partial Signer Map(SignerDto request);

    public partial DocumentDto Map(Document entity);
    public partial Document Map(DocumentDto request);

    public partial ApproverDto Map(Approver entity);
    public partial Approver Map(ApproverDto request);

    [MapEnum(EnumMappingStrategy.ByValue)]
    public partial SignatureFieldEnum Map(SignatureFieldDtoEnum entity);
    [MapEnum(EnumMappingStrategy.ByValue)]
    public partial SignatureWithEnum Map(SignatureDtoWithEnum entity);
    [MapperIgnoreSource(nameof(IBasePaging.Page))]
    [MapperIgnoreSource(nameof(IBasePaging.PageSize))]
    //[MapperIgnoreSource("defaultSorting")]
    //[MapperIgnoreSource("defaultPageSize")]
    //[MapperIgnoreSource("defaultPage")]
    public partial SignatureFilter Map(SignatureDtoFilter entity);

    [MapEnum(EnumMappingStrategy.ByValue)]
    public partial SignerStatusEnum Map(SignerStatusDtoEnum entity);
    [MapEnum(EnumMappingStrategy.ByValue)]
    public partial DocumentNatureEnum Map(DocumentNatureDtoEnum entity);
    [MapEnum(EnumMappingStrategy.ByValue)]
    public partial ApproverStatusEnum Map(ApproverStatusDtoEnum entity);
    [MapEnum(EnumMappingStrategy.ByValue)]
    public partial SignatureStatusEnum Map(SignatureStatusDtoEnum entity);

    [MapEnum(EnumMappingStrategy.ByValue)]
    public partial SignerStatusEnum Map(Webhook.Enums.SignerStatusEnum entity);
    [MapEnum(EnumMappingStrategy.ByValue)]
    public partial DocumentNatureEnum Map(Webhook.Enums.DocumentNatureEnum entity);
    [MapEnum(EnumMappingStrategy.ByValue)]
    public partial ApproverStatusEnum Map(Webhook.Enums.SignatureRequestApproverStatusEnum entity);
    [MapEnum(EnumMappingStrategy.ByValue)]
    public partial SignatureStatusEnum Map(Webhook.Enums.SignatureRequestStatusEnum entity);
    public partial Signer Map(Webhook.SignatureRequestSigner entity);
    public partial Document Map(Webhook.Document entity);
    [MapProperty([nameof(Webhook.SignatureRequestApprover.Info), nameof(Webhook.SignatureRequestApprover.Info.FirstName)],
        nameof(Approver.FirstName))]
    [MapProperty([nameof(Webhook.SignatureRequestApprover.Info), nameof(Webhook.SignatureRequestApprover.Info.LastName)],
        nameof(Approver.LastName))]
    [MapProperty([nameof(Webhook.SignatureRequestApprover.Info), nameof(Webhook.SignatureRequestApprover.Info.Email)],
        nameof(Approver.Email))]
    [MapProperty([nameof(Webhook.SignatureRequestApprover.Info), nameof(Webhook.SignatureRequestApprover.Info.PhoneNumber)],
        nameof(Approver.PhoneNumber))]
    public partial Approver Map(Webhook.SignatureRequestApprover entity);

}
