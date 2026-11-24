using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class Headquarter
{
    [JsonPropertyName("address_line_1")]
    public string? AddressLine1 { get; set; }
    [JsonPropertyName("address_line_2")]
    public string? AddressLine2 { get; set; }
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }
    [JsonPropertyName("city")]
    public string? City { get; set; }
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }
}
