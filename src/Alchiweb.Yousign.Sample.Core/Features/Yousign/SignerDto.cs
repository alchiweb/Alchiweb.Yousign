using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Alchiweb.Yousign.Sample.Core.Custom;
using Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign;

public record SignerDto : DtoBase<Guid>
{
    #region Properties
    [Display(Name = "Statut")]
    public SignerStatusDtoEnum Status { get; set; }
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
