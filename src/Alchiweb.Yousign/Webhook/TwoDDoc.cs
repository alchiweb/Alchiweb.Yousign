using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class TwoDDoc
{
    [JsonPropertyName("full_name")]
    public string? FullName { get; set; }
    [JsonPropertyName("address")]
    public Address Address { get; set; } = new();
}
