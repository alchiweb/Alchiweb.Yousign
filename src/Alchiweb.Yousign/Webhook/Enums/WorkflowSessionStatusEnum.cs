using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WorkflowSessionStatusEnum
{
    [JsonStringEnumMemberName("ongoing")]
    OnGoing = 1,
    [JsonStringEnumMemberName("blocked")]
    Blocked = 2,
    [JsonStringEnumMemberName("done")]
    Done = 3,
}
