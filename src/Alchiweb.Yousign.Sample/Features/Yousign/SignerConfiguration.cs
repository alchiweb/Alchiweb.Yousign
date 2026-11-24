using Alchiweb.Yousign.Sample.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcaneWebhook.Server.Core.Features.Yousign;

public class SignerConfiguration : IEntityTypeConfiguration<Signer>

{
    public void Configure(EntityTypeBuilder<Signer> builder)
    {
        builder.HasKey(s => s.Id);
    }
}
