using System.Text.Json.Serialization;
using Alchiweb.Yousign.Sample.Domain.Enums;
using Ardalis.Specification.EntityFrameworkCore.SharedKernel;

namespace Alchiweb.Yousign.Sample.Domain;

public class Approver : EntityBase<Approver>
{
    #region Properties
    public string Email { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string? PhoneNumber { get; set; }
    public ApproverStatusEnum Status { get; set; }
    #endregion

    #region ID (foreign keys) properties
    public Guid SignatureId { get; set; }
    #endregion

    #region Navigation properties / Objects
    public Signature? Signature { get; set; }
    #endregion

    #region Constructors
    public Approver(Guid id = default) : base(id) { }
    #endregion
}
