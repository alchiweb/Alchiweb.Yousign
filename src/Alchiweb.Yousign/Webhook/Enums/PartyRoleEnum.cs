using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PartyRoleEnum
{
    [JsonStringEnumMemberName("unknown")]
    Unknown = 0,
    [JsonStringEnumMemberName("holder")]
    Holder = 1,
    [JsonStringEnumMemberName("authorized_user")]
    AuthorizedUser = 2,
    [JsonStringEnumMemberName("other")]
    Other = 3,
}
