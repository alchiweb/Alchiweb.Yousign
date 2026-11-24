using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DocumentAnalysisTypeEnum
{
    [JsonStringEnumMemberName("social_security")]
    SocialSecurity = 1,
    [JsonStringEnumMemberName("company_certificate")]
    CompanyCertificate = 2,
    [JsonStringEnumMemberName("business_registration_certificate")]
    BusinessRegistrationCertificate = 3,
    [JsonStringEnumMemberName("driver_licence")]
    DriverLicence = 4,
    [JsonStringEnumMemberName("rne_certificate")]
    RneCertificate = 5,
}
