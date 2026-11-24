using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LocaleEnum
{
    [JsonStringEnumMemberName("en")]
    En = 0,
    [JsonStringEnumMemberName("fr")]
    Fr = 1,
    [JsonStringEnumMemberName("de")]
    De = 2,
    [JsonStringEnumMemberName("it")]
    It = 3,
    [JsonStringEnumMemberName("nl")]
    Nl = 4,
    [JsonStringEnumMemberName("es")]
    Es = 5,
    [JsonStringEnumMemberName("pl")]
    Pl = 6,
}
