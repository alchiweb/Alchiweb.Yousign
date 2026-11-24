using System.Text.Json.Serialization;
using Alchiweb.Yousign.Sample.Domain.Enums;
using AlchiwebApp.PagingFiltering.Filtering;
using AlchiwebApp.PagingFiltering.Filtering.Enums;

namespace Alchiweb.Yousign.Sample.Domain;

public record SignatureFilter : BaseFilter<SignatureFieldEnum>
{
    public FieldFilter<StringFieldFilterEnum, string>[] SearchApproverFilters { get; }
    public FieldFilter<EnumFieldFilterEnum, ApproverStatusEnum>[] SearchApproverStatusFilters { get; }
    public FieldFilter<EnumFieldFilterEnum, SignerStatusEnum>[] SearchSignerStatusFilters { get; }
    public FieldFilter<StringFieldFilterEnum, string>[] DomainFilters { get; }
    public FieldFilter<StringFieldFilterEnum, string>[] NameFilters { get; }
    public FieldFilter<StringFieldFilterEnum, string>[] SenderEmailFilters { get; }
    public FieldFilter<EnumFieldFilterEnum, SignatureStatusEnum>[] StatusFilters { get; }
    public FieldFilter<DateTimeFieldFilterEnum, DateTimeOffset[]>[] LastEventDateFilters { get; }
    public FieldFilter<DateTimeFieldFilterEnum, DateTimeOffset[]>[] DoneDateFilters { get; }
    [JsonConstructor]
    public SignatureFilter(
        FieldFilter<StringFieldFilterEnum, string>[] searchApproverFilters,
        FieldFilter<EnumFieldFilterEnum, ApproverStatusEnum>[] searchApproverStatusFilters,
        FieldFilter<EnumFieldFilterEnum, SignerStatusEnum>[] searchSignerStatusFilters,
        FieldFilter<StringFieldFilterEnum, string>[] domainFilters,
        FieldFilter<StringFieldFilterEnum, string>[] nameFilters,
        FieldFilter<StringFieldFilterEnum, string>[] senderEmailFilters,
        FieldFilter<EnumFieldFilterEnum, SignatureStatusEnum>[] statusFilters,
        FieldFilter<DateTimeFieldFilterEnum, DateTimeOffset[]>[] lastEventDateFilters,
        FieldFilter<DateTimeFieldFilterEnum, DateTimeOffset[]>[] doneDateFilters,
        Dictionary<SignatureFieldEnum, SortingInfos>? sortBy = null
        ) : base(sortBy)
    {
        SearchApproverFilters = searchApproverFilters;
        SearchApproverStatusFilters = searchApproverStatusFilters;
        SearchSignerStatusFilters = searchSignerStatusFilters;
        DomainFilters = domainFilters;
        NameFilters = nameFilters;
        SenderEmailFilters = senderEmailFilters;
        StatusFilters = statusFilters;
        LastEventDateFilters = lastEventDateFilters;
        DoneDateFilters = doneDateFilters;
    }
}
