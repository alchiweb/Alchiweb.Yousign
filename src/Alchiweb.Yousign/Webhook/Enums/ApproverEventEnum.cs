using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApproverEventEnum
{
    [JsonStringEnumMemberName("approver.approved")]
    Approved = 101,
    [JsonStringEnumMemberName("approver.notified")]
    Notified = 102,
    [JsonStringEnumMemberName("approver.rejected")]
    Rejected = 103,
    [JsonStringEnumMemberName("approver.notification_delivery_failed")]
    NotificationDeliveryFailed = 104,
}
