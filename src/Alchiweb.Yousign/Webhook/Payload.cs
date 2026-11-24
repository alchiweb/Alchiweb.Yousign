using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class Payload
{
    [JsonPropertyName("event_id")]
    public Guid EventId { get; set; }
    [JsonPropertyName("event_name")]
    public EventEnum Event { get; set; }
    [JsonPropertyName("event_time")]
    public string EventTime { get; set; } = "";
    [JsonPropertyName("subscription_id")]
    public Guid SubscriptionId { get; set; }
    [JsonPropertyName("subscription_description")]
    public string SubscriptionDescription { get; set; } = "";
    [JsonPropertyName("sandbox")]
    public bool IsSandbox { get; set; }
    [JsonPropertyName("data")]
    public PayloadData Data { get; set; } = new();

}
