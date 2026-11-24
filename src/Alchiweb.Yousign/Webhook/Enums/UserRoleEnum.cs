using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRoleEnum
{
    [JsonStringEnumMemberName("member")]
    Member = 1,
    [JsonStringEnumMemberName("admin")]
    Admin = 2,
}
