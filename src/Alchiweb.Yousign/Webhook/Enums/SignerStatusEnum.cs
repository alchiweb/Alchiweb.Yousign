using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SignerStatusEnum
{
    [JsonStringEnumMemberName("initiated")]
    Initiated = 1,
    [JsonStringEnumMemberName("notified")]
    Notified = 2,
    [JsonStringEnumMemberName("consent_given")]
    ConsentGiven = 3,
    [JsonStringEnumMemberName("verified")]
    Verified = 4,
    [JsonStringEnumMemberName("processing")]
    Processing = 5,
    [JsonStringEnumMemberName("signed")]
    Signed = 6,
    [JsonStringEnumMemberName("error")]
    Error = 7,
    [JsonStringEnumMemberName("aborted")]
    Aborted = 8,
    [JsonStringEnumMemberName("declined")]
    Declined = 9,
}
