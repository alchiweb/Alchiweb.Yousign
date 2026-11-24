using System.ComponentModel.DataAnnotations;
using Alchiweb.Yousign.Sample.Core.Custom;
using Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign;

public record SignatureDto : DtoBase<Guid>
{
    #region Properties
    [Display(Name = "Espace de travail")]
    public Guid WorkspaceId { get; set; }
    [Display(Name = "Identifiant")]
    public string ExternalId { get; set; } = "";
    [Display(Name = "Nom")]
    public string Name { get; set; } = "";
    [Display(Name = "Domaine")]
    public string Domain { get; set; } = "";

    [Display(Name = "Statut")]
    public SignatureStatusDtoEnum SignatureStatus { get; set; }
    [Display(Name = "Email expéditeur")]
    public string SenderEmail { get; set; } = "";
    [Display(Name = "Est sequentiel")]
    public bool IsSequential { get; set; }

    [Display(Name = "Date de création")]
    public DateTimeOffset? CreatedAt { get; set; }
    [Display(Name = "Date de suppression")]
    public DateTimeOffset? DeletedAt { get; set; }
    [Display(Name = "Date d'expiration")]
    public DateTimeOffset? ExpirationDate { get; set; }
    [Display(Name = "Date du dernier événement")]
    public DateTimeOffset? LastEventDate { get; set; }
    [Display(Name = "Date de la fin de la signature")]
    public DateTimeOffset? DoneDate { get; set; }
    #endregion

    #region Navigation properties / Lists
    [Display(Name = "Documents")]
    public ICollection<DocumentDto> Documents { get; } = [];
    [Display(Name = "Approvers")]
    public ICollection<ApproverDto> Approvers { get; } = [];
    [Display(Name = "Signers")]
    public ICollection<SignerDto> Signers { get; } = [];
    #endregion
}
