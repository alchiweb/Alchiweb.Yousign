using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class BankAccountLookupData
{
    [JsonPropertyName("extracted_from_document")]
    public BankExtractedFromDocument? ExtractedFromDocument { get; set; }
}
