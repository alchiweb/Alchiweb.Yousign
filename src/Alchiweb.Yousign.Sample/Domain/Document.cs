using System.Text.Json.Serialization;
using Alchiweb.Yousign.Sample.Domain.Enums;
using Ardalis.Specification.EntityFrameworkCore.SharedKernel;

namespace Alchiweb.Yousign.Sample.Domain;

public class Document : EntityBase<Document>
{
    #region Properties
    public DocumentNatureEnum Nature { get; set; }
    #endregion

    #region ID (foreign keys) properties
    public Guid SignatureId { get; set; }
    #endregion

    #region Navigation properties / Objects
    public Signature? Signature { get; set; }
    #endregion

    #region Constructors
    public Document(Guid id = default) : base(id) { }
    #endregion
}
