using Alchiweb.Yousign.Sample.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alchiweb.Yousign.Sample.Features.Yousign;

public class ApproverConfiguration : IEntityTypeConfiguration<Approver>

{
    public void Configure(EntityTypeBuilder<Approver> builder)
    {
        builder.HasKey(s => s.Id);
    }
}
