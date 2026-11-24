using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DocumentNatureEnum
{
    [JsonStringEnumMemberName("signable_document")]
    SignableDocument = 1,
    [JsonStringEnumMemberName("attachment")]
    Attachment = 2,
}
