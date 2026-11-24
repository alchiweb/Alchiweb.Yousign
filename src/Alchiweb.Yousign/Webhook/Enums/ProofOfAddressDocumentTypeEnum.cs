using System.Text.Json.Serialization;

namespace Alchiweb.Yousign.Webhook.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProofOfAddressDocumentTypeEnum
{
    [JsonStringEnumMemberName("driver_license")]
    DriverLicense = 1,
    [JsonStringEnumMemberName("energy_invoice")]
    EnergyInvoice = 2,
    [JsonStringEnumMemberName("energy_schedule")]
    EnergySchedule = 3,
    [JsonStringEnumMemberName("family_allowance")]
    FamilyAllowance = 4,
    [JsonStringEnumMemberName("id_card")]
    IdCard = 5,
    [JsonStringEnumMemberName("insurance_attestation")]
    InsuranceAttestation = 6,
    [JsonStringEnumMemberName("italian_national_service_card")]
    ItalianNationalServiceCard = 7,
    [JsonStringEnumMemberName("local_residence_tax_notice")]
    LocalResidenceTaxNotice = 8,
    [JsonStringEnumMemberName("passport")]
    Passport = 9,
    [JsonStringEnumMemberName("payslip")]
    Payslip = 10,
    [JsonStringEnumMemberName("photograph")]
    Photograph = 11,
    [JsonStringEnumMemberName("phone_invoice")]
    PhoneInvoice = 12,
    [JsonStringEnumMemberName("property_tax_notice")]
    PropertyTaxNotice = 13,
    [JsonStringEnumMemberName("provider_attestation")]
    ProviderAttestation = 14,
    [JsonStringEnumMemberName("residence_permit")]
    ResidencePermit = 15,
    [JsonStringEnumMemberName("retirement_pension")]
    RetirementPension = 16,
    [JsonStringEnumMemberName("rib")]
    Rib = 17,
    [JsonStringEnumMemberName("tax_justification")]
    TaxJustification = 18,
    [JsonStringEnumMemberName("tax_notice")]
    TaxNotice = 19,
    [JsonStringEnumMemberName("vehicle_registration_certificate")]
    VehicleRegistrationCertificate = 20,
}
