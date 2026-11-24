using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum IdentificationMethodEnum
{
    [JsonStringEnumMemberName("identity_verification")]
    IdentityVerification = 1,
    [JsonStringEnumMemberName("saved_identity")]
    SavedIdentity = 2,
}
