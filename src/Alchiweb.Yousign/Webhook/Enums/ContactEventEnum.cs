using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContactEventEnum
{
    [JsonStringEnumMemberName("contact.created")]
    Created = 201,
}
