using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SignerSignatureLevelEnum
{
    [JsonStringEnumMemberName("electronic_signature")]
    ElectronicSignature = 1,
    [JsonStringEnumMemberName("advanced_electronic_signature")]
    AdvancedElectronicSignature = 2,
    [JsonStringEnumMemberName("qualified_electronic_signature")]
    QualifiedElectronicSignature = 3,
    [JsonStringEnumMemberName("electronic_signature_with_qualified_certificate")]
    ElectronicSignatureWithQualifiedCertificate = 4,
    [JsonStringEnumMemberName("qualified_electronic_signature_mode_1")]
    QualifiedElectronicSignatureMode1 = 5,
}
