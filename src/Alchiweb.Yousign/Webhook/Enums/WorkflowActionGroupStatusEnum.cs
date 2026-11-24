using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WorkflowActionGroupStatusEnum
{
    [JsonStringEnumMemberName("ongoing")]
    OnGoing = 1,
    [JsonStringEnumMemberName("blocked")]
    Blocked = 2,
    [JsonStringEnumMemberName("done")]
    Done = 3,
    [JsonStringEnumMemberName("awaiting")]
    Awaiting = 4,
}
