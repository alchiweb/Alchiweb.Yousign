using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ElectronicSealStatusEnum
{
    [JsonStringEnumMemberName("done")]
    Done = 1,
    [JsonStringEnumMemberName("error")]
    Error = 2,
}
