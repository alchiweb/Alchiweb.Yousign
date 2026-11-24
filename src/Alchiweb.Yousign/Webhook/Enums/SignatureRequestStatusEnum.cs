using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SignatureRequestStatusEnum
{
    [JsonStringEnumMemberName("draft")]
    Draft = 1,
    [JsonStringEnumMemberName("ongoing")]
    OnGoing = 2,
    [JsonStringEnumMemberName("done")]
    Done = 3,
    [JsonStringEnumMemberName("deleted")]
    Deleted = 4,
    [JsonStringEnumMemberName("expired")]
    Expired = 5,
    [JsonStringEnumMemberName("canceled")]
    Canceled = 6,
    [JsonStringEnumMemberName("approval")]
    Approval = 7,
    [JsonStringEnumMemberName("rejected")]
    Rejected = 8,
    [JsonStringEnumMemberName("declined")]
    Declined = 9,
}
