using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class ElectronicSeal
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("status")]
    public ElectronicSealStatusEnum Status { get; set; }
    [JsonPropertyName("signature_level")]
    public ElectronicSealSignatureLevelEnum SignatureLevel { get; set; }
    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }
    [JsonPropertyName("timestamp")]
    public bool IsTimestamp { get; set; }
    [JsonPropertyName("document_id")]
    public Guid DocumentId { get; set; }
    [JsonPropertyName("image_id")]
    public Guid ImageId { get; set; }
}
