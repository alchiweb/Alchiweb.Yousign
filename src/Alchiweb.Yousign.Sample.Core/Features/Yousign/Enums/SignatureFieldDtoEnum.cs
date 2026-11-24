using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
[Flags]
public enum SignatureFieldDtoEnum
{
    Id = 1 << 0,
    Name = 1 << 1,
    SenderEmail = 1 << 2,
    Domain = 1 << 3,
    SignatureStatus = 1 << 4,
    LastEventDate = 1 << 5,
    IsSequential = 1 << 6,
    CreatedAt = 1 << 7,
    DeletedAt = 1 << 8,
    ExpirationDate = 1 << 9,
    DoneDate = 1 << 10,
}
