using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DocumentVerificationEventEnum
{
    [JsonStringEnumMemberName("verification.bank_account.done")]
    BankAccountDone = 301,
    [JsonStringEnumMemberName("verification.identity_document.done")]
    IdentifyDocumentDone = 302,
    [JsonStringEnumMemberName("verification.identity_video.done")]
    IdentifyVideoDone = 303,
    [JsonStringEnumMemberName("verification.company.done")]
    CompanyDone = 304,
}
