using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MatchLevelEnum
{
    [JsonStringEnumMemberName("exact")]
    Exact = 1,
    [JsonStringEnumMemberName("close")]
    Close = 2,
    [JsonStringEnumMemberName("no_match")]
    NoMatch = 3,
}
