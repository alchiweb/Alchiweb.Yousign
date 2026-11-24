using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class Label
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
}
