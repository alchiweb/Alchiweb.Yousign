using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook;

public class DocumentAnalysisExtractedFromDocument
{
    #region Social Security
    [JsonPropertyName("social_security_number")]
    public string? SocialSecurityNumber { get; set; }
    [JsonPropertyName("first_name")] // and Driver Licence
    public string? FirstName { get; set; }
    [JsonPropertyName("last_name")] // and Driver Licence
    public string? LastName { get; set; }
    [JsonPropertyName("full_name")] // and Driver Licence
    public string? FullName { get; set; }
    #endregion
    #region Company Certificate
    [JsonPropertyName("verification_number")]
    public string? VerificationNumber { get; set; }
    [JsonPropertyName("company_name")]  // and RNE Certificate
    public string? CompanyName { get; set; }
    [JsonPropertyName("company_number")]  // and RNE Certificate
    public string? CompanyNumber { get; set; }
    [JsonPropertyName("registered_address")]  // and RNE Certificate
    public string? RegisteredAddress { get; set; }
    [JsonPropertyName("issuance_date")] // and Business Registration Certificate + RNE Certificate
    public DateTimeOffset? IssuanceDate { get; set; } // DateTimeOffset or string?
    [JsonPropertyName("legal_representatives")]
    public LegalRepresentative[]? LegalRepresentatives { get; set; } // and RNE Certificate
    #endregion
    #region Business Registration Certificate
    [JsonPropertyName("company_description")]
    public CompanyDescription? CompanyDescription { get; set; }
    [JsonPropertyName("branch_description")]
    public BranchDescription? BranchDescription { get; set; }
    #endregion
    #region Driver Licence
    [JsonPropertyName("born_on")]
    public DateTimeOffset? BornOn { get; set; }
    [JsonPropertyName("expired_on")]
    public DateTimeOffset? ExpiredOn { get; set; }
    [JsonPropertyName("license_type")]
    public string[]? LicenseType { get; set; }
    #endregion
    #region RNE Certificate
    #endregion
}
