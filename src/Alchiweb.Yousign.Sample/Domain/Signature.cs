using System.Text.Json.Serialization;
using Alchiweb.Yousign.Sample.Domain.Enums;
using Ardalis.Specification.EntityFrameworkCore.SharedKernel;

namespace Alchiweb.Yousign.Sample.Domain;

public class Signature : EntityBase<Signature>
{
    #region Properties
    public Guid WorkspaceId { get; set; }
    public string ExternalId { get; set; } = "";
    public string Name { get; set; } = "";
    public string Domain { get; set; } = "";
    public SignatureStatusEnum SignatureStatus { get; set; }
    public string SenderEmail { get; set; } = "";
    public bool IsSequential { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
    public DateTimeOffset? LastEventDate { get; set; }
    public DateTimeOffset? DoneDate { get; set; }

    #endregion

    #region Navigation properties / Lists
    public ICollection<Document> Documents { get; } = new HashSet<Document>();
    public ICollection<Approver> Approvers { get; } = new HashSet<Approver>();
    public ICollection<Signer> Signers { get; } = new HashSet<Signer>();
    #endregion

    #region Constructors
    public Signature(Guid id = default) : base(id) { }
    #endregion
}
