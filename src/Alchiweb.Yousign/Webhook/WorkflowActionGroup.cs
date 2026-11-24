using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class WorkflowActionGroup
{
    [JsonPropertyName("type")]
    public WorkflowActionGroupTypeEnum Type { get; set; }
    [JsonPropertyName("status")]
    public WorkflowActionGroupStatusEnum Status { get; set; }
    [JsonPropertyName("workflow_session")]
    public WorkflowSession? WorkflowSession { get; set; }
}
