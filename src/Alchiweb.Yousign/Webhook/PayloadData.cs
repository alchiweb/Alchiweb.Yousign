using System.Text.Json.Serialization;
using Alchiweb.Yousign.Webhook.Enums;

namespace Alchiweb.Yousign.Webhook;

public class PayloadData
{
    [JsonPropertyName("approver")]
    public Approver? Approver { get; set; }
    [JsonPropertyName("details")]
    public NotificationFailureDetails? Details { get; set; }

    [JsonPropertyName("contact")]
    public Contact? Contact { get; set; }

    [JsonPropertyName("identity_document")]
    public IdentityDocumentVerification? IdentityDocument { get; set; }
    [JsonPropertyName("identity_video")]
    public IdentityVideoVerification? IdentityVideo { get; set; }
    [JsonPropertyName("bank_account")]
    public BankAccountVerification? BankAccount { get; set; }
    [JsonPropertyName("bank_account_lookup")]
    public BankAccountLookupVerification? BankAccountLookup { get; set; }
    [JsonPropertyName("bank_account_connection")]
    public BankAccountConnectionVerification? BankAccountConnection { get; set; }
    [JsonPropertyName("proof_of_address")]
    public ProofOfAddressVerification? ProofOfAddress { get; set; }
    [JsonPropertyName("company")]
    public CompanyVerification? Company { get; set; }

    [JsonPropertyName("electronic_seal")]
    public ElectronicSeal? ElectronicSeal { get; set; }

    [JsonPropertyName("signature_request")]
    public SignatureRequest? SignatureRequest { get; set; }
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("signer")]
    public Signer? Signer { get; set; }
    [JsonPropertyName("expected_first_name")]
    public string? ExpectedFirstName { get; set; }
    [JsonPropertyName("expected_last_name")]
    public string? ExpectedLastName { get; set; }
    [JsonPropertyName("failure_reasons")]
    public string[]? FailureReasons { get; set; }
    [JsonPropertyName("identification_method")]
    public IdentificationMethodEnum? IdentificationMethod { get; set; }
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    //[JsonPropertyName("reason")]
    //public IdentificationFailedReasonEnum? IdentificationFailedReason { get; set; }

    [JsonPropertyName("action_group")]
    public WorkflowActionGroup? WorkflowActionGroup { get; set; }
    [JsonPropertyName("workflow_session")]
    public WorkflowSession? WorkflowSession { get; set; }

    [JsonPropertyName("user")]
    public User? User { get; set; }

    [JsonPropertyName("document_analysis")]
    public DocumentAnalysis? DocumentAnalysis { get; set; }

}
