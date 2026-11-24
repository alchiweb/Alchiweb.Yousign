using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Alchiweb.Yousign.Sample.Core.Custom;
using Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign;

public record ApproverDto : DtoBase<Guid>
{
    #region Properties
    [Display(Name = "Email")]
    public string Email { get; set; } = "";
    [Display(Name = "Prénom")]
    public string FirstName { get; set; } = "";
    [Display(Name = "Nom")]
    public string LastName { get; set; } = "";
    [Display(Name = "N° de téléphone")]
    public string? PhoneNumber { get; set; }
    [Display(Name = "Statut")]
    public ApproverStatusDtoEnum Status { get; set; }
    #endregion

    #region ID (foreign keys) properties
    [Display(Name = "Signature")]
    [JsonIgnore]
    public Guid SignatureId { get; set; }
    #endregion

    #region Navigation properties / Objects
    [Display(Name = "Signature")]
    [JsonIgnore]
    public SignatureDto? Signature { get; set; }
    #endregion
}
