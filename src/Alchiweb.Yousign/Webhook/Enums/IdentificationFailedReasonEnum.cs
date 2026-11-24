using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum IdentificationFailedReasonEnum
{
    [JsonStringEnumMemberName("identification_document_is_not_conform")]
    IdentificationDocumentIsNotConform = 1,
    [JsonStringEnumMemberName("same_id_after_a_previous_manual_rejection")]
    SameIdAfterAPreviousManualRejection = 2,
    [JsonStringEnumMemberName("identity_mismatch")]
    IdentityMismatch = 3,
    [JsonStringEnumMemberName("other")]
    Other = 4,
}
