using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class BankAccountVerification
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("workspace_id")]
    public Guid WorkspaceId { get; set; }
    [JsonPropertyName("workflow_session_id")]
    public Guid? WorkflowSessionId { get; set; }
    [JsonPropertyName("previous_attempt_id")]
    public Guid? PreviousAttemptId { get; set; }
    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }
    [JsonPropertyName("status")]
    public VerificationStatusEnum Status { get; set; }
    [JsonPropertyName("status_codes")]
    public string[] StatusCodes { get; set; } = [];
    [JsonPropertyName("data_anonymized")]
    public bool IsDataAnonymized { get; set; }
}
