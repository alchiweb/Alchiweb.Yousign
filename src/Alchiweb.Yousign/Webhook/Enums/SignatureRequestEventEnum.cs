using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SignatureRequestEventEnum
{
    [JsonStringEnumMemberName("signature_request.activated")]
    Activated = 501,
    [JsonStringEnumMemberName("signature_request.approved")]
    Approved = 502,
    [JsonStringEnumMemberName("signature_request.canceled")]
    Canceled = 503,
    [JsonStringEnumMemberName("signature_request.declined")]
    Declined = 504,
    [JsonStringEnumMemberName("signature_request.deleted")]
    Deleted = 505,
    [JsonStringEnumMemberName("signature_request.done")]
    Done = 506,
    [JsonStringEnumMemberName("signature_request.expired")]
    Expired = 507,
    [JsonStringEnumMemberName("signature_request.permanently_deleted")]
    PermanentlyDeleted = 508,
    [JsonStringEnumMemberName("signature_request.reactivated")]
    Reactivated = 509,
    [JsonStringEnumMemberName("signature_request.reminder_executed")]
    ReminderExecuted = 510,
    [JsonStringEnumMemberName("signature_request.automatic_reminder_executed")]
    AutomaticReminderExecuted = 511,
    [JsonStringEnumMemberName("signature_request.rejected")]
    Rejected = 512,
}
