using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SignatureRequestApproverStatusEnum
{
    [JsonStringEnumMemberName("initiated")]
    Initiated = 1,
    [JsonStringEnumMemberName("notified")]
    Notified = 2,
    [JsonStringEnumMemberName("approved")]
    Approved = 3,
    [JsonStringEnumMemberName("rejected")]
    Rejected = 4,
}
