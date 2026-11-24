using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class SignerConsentRequest
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; } = "";
    [JsonPropertyName("optional")]
    public bool IsOptional { get; set; }
    [JsonPropertyName("document_id")]
    public Guid? DocumentId { get; set; }
    [JsonPropertyName("checked")]
    public bool? IsChecked { get; set; }
    [JsonPropertyName("filled_text")]
    public string? FilledText { get; set; }
}
