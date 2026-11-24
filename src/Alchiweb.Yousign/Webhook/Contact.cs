using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class Contact
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
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

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }
    [JsonPropertyName("job_title")]
    public string? JobTitle { get; set; }
    [JsonPropertyName("address_line_1")]
    public string? AddressLine1 { get; set; }
    [JsonPropertyName("address_line_2")]
    public string? AddressLine2 { get; set; }
    [JsonPropertyName("address_city")]
    public string? AddressCity { get; set; }
    [JsonPropertyName("address_postal_code")]
    public string? AddressPostalCode { get; set; }
    [JsonPropertyName("address_country")]
    public string? AddressCountry { get; set; }
    [JsonPropertyName("workspace_id")]
    public Guid? WorkspaceId { get; set; }
}
