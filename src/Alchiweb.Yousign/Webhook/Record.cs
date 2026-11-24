using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class Record
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("active")]
    public bool IsActive { get; set; }
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }
    [JsonPropertyName("started_on")]
    public DateTimeOffset? StartedOn { get; set; } // DateTimeOffset or string?
    [JsonPropertyName("ended_on")]
    public DateTimeOffset? EndedOn { get; set; } // DateTimeOffset or string?

    [JsonPropertyName("sources")]
    public Source[] Sources { get; set; } = [];
}
