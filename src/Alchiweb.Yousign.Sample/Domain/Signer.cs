using System.Text.Json.Serialization;
using Alchiweb.Yousign.Sample.Domain.Enums;
using Ardalis.Specification.EntityFrameworkCore.SharedKernel;

namespace Alchiweb.Yousign.Sample.Domain;

public class Signer : EntityBase<Signer>
{
    #region Properties
    public SignerStatusEnum Status { get; set; }
    #endregion

    #region ID (foreign keys) properties
    public Guid SignatureId { get; set; }
    #endregion

    #region Navigation properties / Objects
    public Signature? Signature { get; set; }
    #endregion

    #region Constructors
    public Signer(Guid id = default) : base(id) { }
    #endregion
}
