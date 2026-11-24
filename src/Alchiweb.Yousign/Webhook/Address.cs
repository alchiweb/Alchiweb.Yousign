using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class Address
{
    [JsonPropertyName("line1")]
    public string? Line1 { get; set; }
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }
    [JsonPropertyName("city")]
    public string? City { get; set; }
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }
}
