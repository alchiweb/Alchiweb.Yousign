using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class BankAccountConnectionData
{
    [JsonPropertyName("data")]
    public BankAccountConnectionDataData Data { get; set; } = new();
}
