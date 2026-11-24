using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class BankExtractedFromDocument
{
    [JsonPropertyName("iban")]
    public string? Iban { get; set; }
}
