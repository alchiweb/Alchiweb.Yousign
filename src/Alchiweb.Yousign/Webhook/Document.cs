using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class Document
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("nature")]
    public DocumentNatureEnum Nature { get; set; }
}
