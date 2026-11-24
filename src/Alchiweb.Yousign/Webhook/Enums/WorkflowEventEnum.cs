using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WorkflowEventEnum
{
    [JsonStringEnumMemberName("workflow_action_group.started")]
    ActionGroupStarted = 801,
    [JsonStringEnumMemberName("workflow_action_group.blocked")]
    ActionGroupBlocked = 802,
    [JsonStringEnumMemberName("workflow_action_group.done")]
    ActionGroupDone = 803,
    [JsonStringEnumMemberName("workflow_session.started")]
    SessionStarted = 804,
    [JsonStringEnumMemberName("workflow_session.blocked")]
    SessionBlocked = 805,
    [JsonStringEnumMemberName("workflow_session.done")]
    SessionDone = 806,
}
