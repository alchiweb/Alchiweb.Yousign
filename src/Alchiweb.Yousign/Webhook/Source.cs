using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class Source
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
