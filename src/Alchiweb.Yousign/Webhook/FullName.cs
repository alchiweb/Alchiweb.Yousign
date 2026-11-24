using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class FullName
{
    [JsonPropertyName("expected")]
    public string Expected { get; set; } = "";
    [JsonPropertyName("extracted")]
    public string? Extracted { get; set; }
    [JsonPropertyName("match_level")]
    public MatchLevelEnum MatchLevel { get; set; }
}
