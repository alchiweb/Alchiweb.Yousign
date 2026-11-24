using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class LegalRepresentative
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("birth_name")]
    public string? BirthName { get; set; }
    [JsonPropertyName("born_on")]
    public DateTimeOffset? BornOn { get; set; }
    [JsonPropertyName("type")]
    public LegalRepresentativeTypeEnum Type { get; set; }
    [JsonPropertyName("function")]
    public string? Function { get; set; }
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    [JsonPropertyName("full_name")]
    public string? FullName { get; set; }
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }
    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }
}
