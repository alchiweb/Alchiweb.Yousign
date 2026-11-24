using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SignatureAuthenticationModeEnum
{
    [JsonStringEnumMemberName("no_code")]
    NoCode = 1,
    [JsonStringEnumMemberName("sms")]
    Sms = 2,
    [JsonStringEnumMemberName("otp_by_email")]
    OtpByEmail = 3,
}
