using Alchiweb.Yousign.Sample.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcaneWebhook.Server.Core.Features.Yousign;

public class SignatureConfiguration : IEntityTypeConfiguration<Signature>

{
    public void Configure(EntityTypeBuilder<Signature> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Domain)
            // stored could be false if PostgreSQL version >= 18
            .HasComputedColumnSql(@"SUBSTRING(""ExternalId"",0,PATINDEX('%[__]%',""ExternalId""))", stored: false);

        builder.HasMany(s => s.Documents)
            .WithOne(d => d.Signature)
            .HasForeignKey(d => d.SignatureId)
            .IsRequired();
    
        builder.HasMany(s => s.Signers)
            .WithOne(d => d.Signature)
            .HasForeignKey(d => d.SignatureId)
            .IsRequired();
    }
}
