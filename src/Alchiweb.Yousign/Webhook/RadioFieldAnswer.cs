using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class RadioFieldAnswer
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("x")]
    public int X { get; set; }
    [JsonPropertyName("y")]
    public int Y { get; set; }
    [JsonPropertyName("checked")]
    public bool IsChecked { get; set; }
}
