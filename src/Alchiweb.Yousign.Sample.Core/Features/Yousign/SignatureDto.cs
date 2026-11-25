using System.ComponentModel.DataAnnotations;
using Alchiweb.Yousign.Sample.Core.Custom;
using Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign;

public record SignatureDto : DtoBase<Guid>
{
    #region Properties
    [Display(Name = "Workspace")]
    public Guid WorkspaceId { get; set; }
    [Display(Name = "Id")]
    public string ExternalId { get; set; } = "";
    [Display(Name = "Name")]
    public string Name { get; set; } = "";
    [Display(Name = "Domain")]
    public string Domain { get; set; } = "";

    [Display(Name = "Status")]
    public SignatureStatusDtoEnum SignatureStatus { get; set; }
    [Display(Name = "Sender email")]
    public string SenderEmail { get; set; } = "";
    [Display(Name = "Is sequential")]
    public bool IsSequential { get; set; }

    [Display(Name = "Creating date")]
    public DateTimeOffset? CreatedAt { get; set; }
    [Display(Name = "Deleting date")]
    public DateTimeOffset? DeletedAt { get; set; }
    [Display(Name = "Expiration date")]
    public DateTimeOffset? ExpirationDate { get; set; }
    [Display(Name = "Last event date")]
    public DateTimeOffset? LastEventDate { get; set; }
    [Display(Name = "Done date")]
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
