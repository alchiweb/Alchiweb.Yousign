using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ElectronicSealSignatureLevelEnum
{
    [JsonStringEnumMemberName("electronic_signature")]
    ElectronicSignature = 1,
    [JsonStringEnumMemberName("advanced_electronic_signature")]
    AdvancedElectronicSignature = 2,
    [JsonStringEnumMemberName("qualified_electronic_signature")]
    QualifiedElectronicSignature = 3,
}
