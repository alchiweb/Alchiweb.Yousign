using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserEventEnum
{
    [JsonStringEnumMemberName("user.completed")]
    Completed = 701,
}
