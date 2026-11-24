using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class CompanyActivity
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("classification")]
    public string? Classification { get; set; }
}
