using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class LegalForm
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
