using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class Sanctions
{
    [JsonPropertyName("active")]
    public bool IsActive { get; set; }
    [JsonPropertyName("records")]
    public Record[] Records { get; set; } = [];
}
