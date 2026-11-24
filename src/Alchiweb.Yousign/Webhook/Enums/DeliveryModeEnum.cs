using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DeliveryModeEnum
{
    [JsonStringEnumMemberName("none")]
    None = 0,
    [JsonStringEnumMemberName("email")]
    Email = 1,
}
