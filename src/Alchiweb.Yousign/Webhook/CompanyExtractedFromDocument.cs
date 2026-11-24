using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class CompanyExtractedFromDocument
{
    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }
    [JsonPropertyName("issued_on")]
    public DateTimeOffset? IssuedOn { get; set; }
}
