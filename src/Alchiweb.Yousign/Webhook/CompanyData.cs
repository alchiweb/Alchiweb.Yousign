using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class CompanyData
{
    [JsonPropertyName("extracted_from_document")]
    public CompanyExtractedFromDocument? CompanyExtractedFromDocument { get; set; }
    [JsonPropertyName("company_information")]
    public CompanyInformation? CompanyInformation { get; set; }
    [JsonPropertyName("headquarter")]
    public Headquarter? Headquarter { get; set; }
    [JsonPropertyName("legal_representatives")]
    public LegalRepresentative[]? LegalRepresentatives { get; set; }
}
