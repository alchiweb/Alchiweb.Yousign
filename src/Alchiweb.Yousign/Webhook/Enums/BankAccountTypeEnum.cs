using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BankAccountTypeEnum
{
    [JsonStringEnumMemberName("personal")]
    Personal = 1,
    [JsonStringEnumMemberName("business")]
    Business = 2,
}
