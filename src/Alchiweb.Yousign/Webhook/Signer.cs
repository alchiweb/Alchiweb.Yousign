using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class Signer
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("info")]
    public Info Info { get; set; } = new();
    [JsonPropertyName("status")]
    public SignerStatusEnum Status { get; set; }
    [JsonPropertyName("delivery_mode")]
    public DeliveryModeEnum? DeliveryMode { get; set; }
    [JsonPropertyName("signature_level")]
    public SignerSignatureLevelEnum SignatureLevel { get; set; }
    [JsonPropertyName("signature_authentication_mode")]
    public SignatureAuthenticationModeEnum SignatureAuthenticationMode { get; set; }
    [JsonPropertyName("answers")]
    public FieldAnswer[] Answers { get; set; } = [];
    [JsonPropertyName("consent_requests")]
    public SignerConsentRequest[] ConsentRequests { get; set; } = [];
}
