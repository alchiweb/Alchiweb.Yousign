using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class User
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; } = "";
    [JsonPropertyName("locale")]
    public LocaleEnum? Locale { get; set; }
    [JsonPropertyName("status")]
    public UserStatusEnum? Status { get; set; }
    [JsonPropertyName("is_active")]
    public bool? IsActive { get; set; }
    [JsonPropertyName("role")]
    public UserRoleEnum? Role { get; set; }
}
