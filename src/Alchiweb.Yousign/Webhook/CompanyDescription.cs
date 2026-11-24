using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class CompanyDescription
{
    [JsonPropertyName("active")]
    public bool? IsActive { get; set; }
    [JsonPropertyName("legal_form")]
    public string? LegalForm { get; set; }
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }
    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }
    [JsonPropertyName("headquarter_company_number")]
    public string? HeadquarterCompanyNumber { get; set; }
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    [JsonPropertyName("full_name")]
    public string? FullName { get; set; }
}
