using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class PoliticallyExposedPerson
{
    [JsonPropertyName("active")]
    public bool IsActive { get; set; }
    [JsonPropertyName("positions")]
    public Record[] Positions { get; set; } = [];
}
