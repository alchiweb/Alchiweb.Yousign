using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class WatchlistData
{
    [JsonPropertyName("politically_exposed_person")]
    public PoliticallyExposedPerson? PoliticallyExposedPerson { get; set; }
    [JsonPropertyName("sanctions")]
    public Sanctions? Sanctions { get; set; }
}
