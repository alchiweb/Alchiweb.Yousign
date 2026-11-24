using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VerificationStatusEnum
{
    [JsonStringEnumMemberName("pending")]
    Pending = 1,
    [JsonStringEnumMemberName("verified")]
    Verified = 2,
    [JsonStringEnumMemberName("failed")]
    Failed = 3,
    [JsonStringEnumMemberName("inconclusive")]
    Inconclusive = 4,
}
