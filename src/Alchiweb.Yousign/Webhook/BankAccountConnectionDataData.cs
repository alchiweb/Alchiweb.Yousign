using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class BankAccountConnectionDataData
{
    [JsonPropertyName("account_type")]
    public BankAccountTypeEnum? AccountType { get; set; }
    [JsonPropertyName("bank_name")]
    public string? BankName { get; set; }
    [JsonPropertyName("account_identifiers")]
    public AccountIdentifiers AccountIdentifiers { get; set; } = new();
    [JsonPropertyName("parties")]
    public Party[] Parties { get; set; } = [];
    [JsonPropertyName("checks")]
    public Checks? Checks { get; set; }
}
