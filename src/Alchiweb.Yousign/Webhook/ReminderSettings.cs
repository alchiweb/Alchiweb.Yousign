using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class ReminderSettings
{
    [JsonPropertyName("interval_in_days")]
    public int IntervalInDays { get; set; }
    [JsonPropertyName("max_occurrences")]
    public int MaxOccurrences { get; set; }
}
