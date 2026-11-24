using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SignatureDtoWithEnum
{
    None = 0,
    All = 1,
    Approvers = 2,
    Documents = 3,
    Signers = 4,
}
