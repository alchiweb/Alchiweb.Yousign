using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DocumentNatureDtoEnum
{
    [JsonStringEnumMemberName("signable_document")]
    SignableDocument = 1,
    [JsonStringEnumMemberName("attachment")]
    Attachment = 2,
}
