using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class SignatureRequest
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }
    [JsonPropertyName("workspace_id")]
    public Guid? WorkspaceId { get; set; }

    [JsonPropertyName("status")]
    public SignatureRequestStatusEnum? Status { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("delivery_mode")]
    public DeliveryModeEnum? DeliveryMode { get; set; }
    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("deleted_at")]
    public DateTimeOffset? DeletedAt { get; set; }
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }
    [JsonPropertyName("expiration_date")]
    public DateTimeOffset? ExpirationDate { get; set; }
    [JsonPropertyName("source")]
    public SignatureRequestSourceEnum? Source { get; set; }
    [JsonPropertyName("ordered_signers")]
    public bool? IsOrderedSigners { get; set; }
    [JsonPropertyName("sender")]
    public User? Sender { get; set; }
    [JsonPropertyName("reminder_settings")]
    public ReminderSettings? ReminderSettings { get; set; }
    [JsonPropertyName("signers")]
    public SignatureRequestSigner[]? Signers { get; set; }
    [JsonPropertyName("approvers")]
    public SignatureRequestApprover[]? Approvers { get; set; }
    [JsonPropertyName("labels")]
    public Label[]? Labels { get; set; }
    [JsonPropertyName("documents")]
    public Document[]? Documents { get; set; }
}
