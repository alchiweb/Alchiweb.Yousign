using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class NotificationFailureDetails
{
    [JsonPropertyName("status")]
    public NotificationStatusEnum Status { get; set; }
    [JsonPropertyName("additional_information")]
    public string AdditionalInformation { get; set; } = "";
}
