using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class AccountIdentifiers
{

    [JsonPropertyName("iban")]
    public string? Iban { get; set; }
    [JsonPropertyName("bic")]
    public string? Bic { get; set; }
}
