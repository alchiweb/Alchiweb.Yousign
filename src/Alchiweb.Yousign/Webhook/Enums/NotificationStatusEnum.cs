using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NotificationStatusEnum
{
    [JsonStringEnumMemberName("failed_sending_to_provider")]
    FailedSendingToProvider = 1,
    [JsonStringEnumMemberName("soft_bounced")]
    SoftBounced = 2,
    [JsonStringEnumMemberName("hard_bounced")]
    HardBounced = 3,
    [JsonStringEnumMemberName("blocked")]
    Blocked = 4,
    [JsonStringEnumMemberName("spam")]
    Spam = 5,
    [JsonStringEnumMemberName("rejected")]
    Rejected = 6,
}
