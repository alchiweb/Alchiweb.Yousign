using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class Info
{
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = "";
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = "";
    [JsonPropertyName("email")]
    public string Email { get; set; } = "";
    [JsonPropertyName("locale")]
    public LocaleEnum Locale { get; set; }
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }
    [JsonPropertyName("recipient_stage_index")]
    public int RecipientStageIndex { get; set; }
}
