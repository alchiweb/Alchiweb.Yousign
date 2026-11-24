using System.ComponentModel.DataAnnotations;
using AlchiwebApp.Core.Interfaces;

namespace Alchiweb.Yousign.Sample.Core.Custom;

public abstract record DtoBase<TId> : IEntityDto<TId> where TId : struct, IEquatable<TId>
{
    [Display(Name = "Id")]
    public TId Id { get; init; } = default;
}
