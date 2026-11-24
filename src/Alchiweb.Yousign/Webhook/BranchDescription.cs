using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class BranchDescription
{

    [JsonPropertyName("address")]
    public string? Address { get; set; }
    [JsonPropertyName("city")]
    public string?City { get; set; }
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }
    [JsonPropertyName("active")]
    public bool? IsActive { get; set; }
    [JsonPropertyName("branch_company_number")]
    public string? BranchCompanyNumber { get; set; }
}
