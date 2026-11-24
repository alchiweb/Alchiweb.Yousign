using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class CompanyInformation
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("trade_name")]
    public string? TradeName { get; set; }
    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }
    [JsonPropertyName("partial_data")]
    public bool? IsPartialData { get; set; }
    [JsonPropertyName("legal_form")]
    public LegalForm? LegalForm { get; set; }
    [JsonPropertyName("vat_number")]
    public string? VatCompanyNumber { get; set; }
    [JsonPropertyName("activities")]
    public CompanyActivity[]? Activities { get; set; }

    [JsonPropertyName("founded_on")]
    public DateTimeOffset? FoundedOn { get; set; }
    [JsonPropertyName("ceased_on")]
    public DateTimeOffset? CeasedOn { get; set; }

    [JsonPropertyName("active")]
    public bool? IsActive { get; set; }
    [JsonPropertyName("commercial_registration")]
    public CommercialRegistration? CommercialRegistration { get; set; }
    [JsonPropertyName("has_workforce")]
    public bool? HasWorkforce { get; set; }
}
