using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApproverStatusDtoEnum
{
    [JsonStringEnumMemberName("initiated")]
    Initiated = 1,
    [JsonStringEnumMemberName("notified")]
    Notified = 2,
    [JsonStringEnumMemberName("approved")]
    Approved = 3,
    [JsonStringEnumMemberName("rejected")]
    Rejected = 4,
}
