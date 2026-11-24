using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class Approver
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("info")]
    public Info Info { get; set; } = new();
}
