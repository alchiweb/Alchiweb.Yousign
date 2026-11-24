using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SignerEventEnum
{
    [JsonStringEnumMemberName("signer.declined")]
    Declined = 601,
    [JsonStringEnumMemberName("signer.done")]
    Done = 602,
    [JsonStringEnumMemberName("signer.error")]
    Error = 603,
    [JsonStringEnumMemberName("signer.identification_blocked")]
    IdentificationBlocked = 604,
    [JsonStringEnumMemberName("signer.identification_failed")]
    IdentificationFailed = 605,
    [JsonStringEnumMemberName("signer.identification_succeeded")]
    IdentificationSucceeded = 606,
    [JsonStringEnumMemberName("signer.identity_saved")]
    IdentitySaved = 607,
    [JsonStringEnumMemberName("signer.link_opened")]
    LinkOpened = 608,
    [JsonStringEnumMemberName("signer.notified")]
    Notified = 609,
    [JsonStringEnumMemberName("signer.sender_contacted")]
    SenderContacted = 610,
    [JsonStringEnumMemberName("signer.notification_delivery_failed")]
    NotificationDeliveryFailed = 611,
}
