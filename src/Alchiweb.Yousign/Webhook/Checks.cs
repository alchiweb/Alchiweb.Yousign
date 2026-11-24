using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class Checks
{
    [JsonPropertyName("full_name")]
    public FullName FullName { get; set; } = new();
}
