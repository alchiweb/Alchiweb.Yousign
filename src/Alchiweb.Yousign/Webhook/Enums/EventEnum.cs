using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EventEnum
{
    //None = 0,
    [JsonStringEnumMemberName("approver.approved")]
    ApproverApproved = 101,
    [JsonStringEnumMemberName("approver.notified")]
    ApproverNotified = 102,
    [JsonStringEnumMemberName("approver.rejected")]
    ApproverRejected = 103,
    [JsonStringEnumMemberName("approver.notification_delivery_failed")]
    ApproverNotificationDeliveryFailed = 104,

    [JsonStringEnumMemberName("contact.created")]
    ContactCreated = 201,
    
    [JsonStringEnumMemberName("verification.bank_account.done")]
    VerificationBankAccountDone = 301,
    [JsonStringEnumMemberName("verification.identity_document.done")]
    VerificationIdentifyDocumentDone = 302,
    [JsonStringEnumMemberName("verification.identity_video.done")]
    VerificationIdentifyVideoDone = 303,
    [JsonStringEnumMemberName("verification.company.done")]
    VerificationCompanyDone = 304,

    [JsonStringEnumMemberName("electronic_seal.done")]
    Done = 401,
    [JsonStringEnumMemberName("electronic_seal.error")]
    Error = 402,

    [JsonStringEnumMemberName("signature_request.activated")]
    SignatureRequestActivated = 501,
    [JsonStringEnumMemberName("signature_request.approved")]
    SignatureRequestApproved = 502,
    [JsonStringEnumMemberName("signature_request.canceled")]
    SignatureRequestCanceled = 503,
    [JsonStringEnumMemberName("signature_request.declined")]
    SignatureRequestDeclined = 504,
    [JsonStringEnumMemberName("signature_request.deleted")]
    SignatureRequestDeleted = 505,
    [JsonStringEnumMemberName("signature_request.done")]
    SignatureRequestDone = 506,
    [JsonStringEnumMemberName("signature_request.expired")]
    SignatureRequestExpired = 507,
    [JsonStringEnumMemberName("signature_request.permanently_deleted")]
    SignatureRequestPermanentlyDeleted = 508,
    [JsonStringEnumMemberName("signature_request.reactivated")]
    SignatureRequestReactivated = 509,
    [JsonStringEnumMemberName("signature_request.reminder_executed")]
    SignatureRequestReminderExecuted = 510,
    [JsonStringEnumMemberName("signature_request.automatic_reminder_executed")]
    SignatureRequestAutomaticReminderExecuted = 511,
    [JsonStringEnumMemberName("signature_request.rejected")]
    SignatureRequestRejected = 512,

    [JsonStringEnumMemberName("signer.declined")]
    SignerDeclined = 601,
    [JsonStringEnumMemberName("signer.done")]
    SignerDone = 602,
    [JsonStringEnumMemberName("signer.error")]
    SignerError = 603,
    [JsonStringEnumMemberName("signer.identification_blocked")]
    SignerIdentificationBlocked = 604,
    [JsonStringEnumMemberName("signer.identification_failed")]
    SignerIdentificationFailed = 605,
    [JsonStringEnumMemberName("signer.identification_succeeded")]
    SignerIdentificationSucceeded = 606,
    [JsonStringEnumMemberName("signer.identity_saved")]
    SignerIdentitySaved = 607,
    [JsonStringEnumMemberName("signer.link_opened")]
    SignerLinkOpened = 608,
    [JsonStringEnumMemberName("signer.notified")]
    SignerNotified = 609,
    [JsonStringEnumMemberName("signer.sender_contacted")]
    SignerSenderContacted = 610,
    [JsonStringEnumMemberName("signer.notification_delivery_failed")]
    SignerNotificationDeliveryFailed = 611,

    [JsonStringEnumMemberName("user.completed")]
    UserCompleted = 701,

    [JsonStringEnumMemberName("workflow_action_group.started")]
    WorkflowActionGroupStarted = 801,
    [JsonStringEnumMemberName("workflow_action_group.blocked")]
    WorkflowActionGroupBlocked = 802,
    [JsonStringEnumMemberName("workflow_action_group.done")]
    WorkflowActionGroupDone = 803,
    [JsonStringEnumMemberName("workflow_session.started")]
    WorkflowSessionStarted = 804,
    [JsonStringEnumMemberName("workflow_session.blocked")]
    WorkflowSessionBlocked = 805,
    [JsonStringEnumMemberName("workflow_session.done")]
    WorkflowSessionDone = 806,
}
