using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WorkflowActionGroupTypeEnum
{
    [JsonStringEnumMemberName("signature_request")]
    SignatureRequest = 1,
    [JsonStringEnumMemberName("identity_verification")]
    IdentityVerification = 2,
    [JsonStringEnumMemberName("proof_of_address_verification")]
    ProofOfAddressVerification = 3,
    [JsonStringEnumMemberName("company_verification")]
    CompanyVerification = 4,
    [JsonStringEnumMemberName("watchlist_verification")]
    WatchlistVerification = 5,
    [JsonStringEnumMemberName("bank_account_verification")]
    BankAccountVerification = 6,
}
