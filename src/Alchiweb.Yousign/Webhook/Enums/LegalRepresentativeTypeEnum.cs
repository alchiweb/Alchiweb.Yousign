using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LegalRepresentativeTypeEnum
{
    [JsonStringEnumMemberName("natural_person")]
    NaturalPerson = 1,
    [JsonStringEnumMemberName("legal_person")]
    LegalPerson = 2,
}
