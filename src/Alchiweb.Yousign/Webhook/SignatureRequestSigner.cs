using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class SignatureRequestSigner
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("status")]
    public SignerStatusEnum Status { get; set; }
    [JsonPropertyName("delivery_mode")]
    public DeliveryModeEnum? DeliveryMode { get; set; }
    [JsonPropertyName("answers")]
    public FieldAnswer[] Answers { get; set; } = [];
}
