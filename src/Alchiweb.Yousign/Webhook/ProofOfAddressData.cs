using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class ProofOfAddressData
{
    [JsonPropertyName("extracted_from_document")]
    public ProofOfAddressExtractedFromDocument? ExtractedFromDocument { get; set; }
}
