using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class SignatureRequestApprover
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("info")]
    public Info Info { get; set; } = new();
    [JsonPropertyName("status")]
    public SignatureRequestApproverStatusEnum Status { get; set; }
}
