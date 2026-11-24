using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class Party
{
    [JsonPropertyName("role")]
    public PartyRoleEnum Role { get; set; }
    [JsonPropertyName("full_name")]
    public string? FullName { get; set; }
    [JsonPropertyName("legal_person_name")]
    public string? LegalPersonName { get; set; }
}
