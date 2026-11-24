using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class ProofOfAddressExtractedFromDocument
{
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    [JsonPropertyName("full_address")]
    public string? FullAddress { get; set; }
    [JsonPropertyName("issued_on")]
    public DateTimeOffset? IssuedOn { get; set; }

    [JsonPropertyName("document_type")]
    public ProofOfAddressDocumentTypeEnum? DocumentType { get; set; }

    [JsonPropertyName("2d_doc")]
    public TwoDDoc TwoDDoc { get; set; } = new();
}
