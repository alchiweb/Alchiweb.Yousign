using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class CommercialRegistration
{
    [JsonPropertyName("location")]
    public string? Location { get; set; }
    [JsonPropertyName("registered_on")]
    public DateTimeOffset? RegisteredOn { get; set; }
}
