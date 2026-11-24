using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserStatusEnum
{
    [JsonStringEnumMemberName("completed")]
    Completed = 1,
}
