using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ElectronicSealEventEnum
{
    [JsonStringEnumMemberName("electronic_seal.done")]
    Done = 401,
    [JsonStringEnumMemberName("electronic_seal.error")]
    Error = 402,
}
