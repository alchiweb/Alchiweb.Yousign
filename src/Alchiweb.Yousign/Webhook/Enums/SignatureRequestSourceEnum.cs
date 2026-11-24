using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SignatureRequestSourceEnum
{
    [JsonStringEnumMemberName("app")]
    App = 1,
    [JsonStringEnumMemberName("public_api")]
    PublicApi = 2,
    [JsonStringEnumMemberName("hubspot_integration")]
    HubspotIntegration = 3,
    [JsonStringEnumMemberName("connector_zapier_api")]
    ConnectorZapierApi = 4,
}
