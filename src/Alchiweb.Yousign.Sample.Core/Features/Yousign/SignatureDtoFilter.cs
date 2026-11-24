using System.Text.Json.Serialization;
using AlchiwebApp.PagingFiltering.Filtering;
using AlchiwebApp.PagingFiltering.Filtering.Enums;
using Alchiweb.Yousign.Sample.Core.Custom;
using Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign;

public record SignatureDtoFilter : BasePagingDto<SignatureFieldDtoEnum, SignatureDtoFilter>
{
    [JsonPropertyName("signerStatus")]
    public List<FieldFilter<EnumFieldFilterEnum, SignerStatusDtoEnum>> SearchSignerStatusFilters { get; set; } = [];
    [JsonPropertyName("approver")]
    public List<FieldFilter<StringFieldFilterEnum, string>> SearchApproverFilters { get; set; } = [];
    [JsonPropertyName("approverStatus")]
    public List<FieldFilter<EnumFieldFilterEnum, ApproverStatusDtoEnum>> SearchApproverStatusFilters { get; set; } = [];
    [JsonPropertyName("domain")]
    public List<FieldFilter<StringFieldFilterEnum, string>> DomainFilters { get; set; } = [];
    [JsonPropertyName("name")]
    public List<FieldFilter<StringFieldFilterEnum, string>> NameFilters { get; set; } = [];
    [JsonPropertyName("senderEmail")]
    public List<FieldFilter<StringFieldFilterEnum, string>> SenderEmailFilters { get; set; } = [];
    [JsonPropertyName("status")]
    public List<FieldFilter<EnumFieldFilterEnum, SignatureStatusDtoEnum>> StatusFilters { get; set; } = [];
    [JsonPropertyName("lastEventdate")]
    public List<FieldFilter<DateTimeFieldFilterEnum, DateTimeOffset[]>> LastEventDateFilters { get; set; } = [];
    [JsonPropertyName("date")]
    public List<FieldFilter<DateTimeFieldFilterEnum, DateTimeOffset[]>> DoneDateFilters { get; set; } = [];
    [JsonConstructor]
    public SignatureDtoFilter() : this(null, null, null) { }

    public SignatureDtoFilter(SignatureFieldDtoEnum? sorting = null, int? pageSize = null, int? page = null) : base(sorting, pageSize, page) { }

    public override string ToString() => base.ToString();
}
