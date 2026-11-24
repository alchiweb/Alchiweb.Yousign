using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class FieldAnswer
{
    [JsonPropertyName("field_id")]
    public Guid Id { get; set; }
    [JsonPropertyName("field_type")]
    public string Type { get; set; } = "";
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("question")]
    public string? Question { get; set; }
    [JsonPropertyName("answer")]
    public string? Answer { get; set; }
    [JsonPropertyName("default_value")]
    public string? DefaultValue { get; set; }
    [JsonPropertyName("read_only")]
    public bool IsReadOnly { get; set; }
    [JsonPropertyName("checked")]
    public bool? IsChecked { get; set; }
    [JsonPropertyName("default_checked")]
    public bool? IsDefaultChecked { get; set; }
    [JsonPropertyName("optional")]
    public bool? IsOptional { get; set; }
    [JsonPropertyName("radios")]
    public RadioFieldAnswer[]? Radios { get; set; }
}
