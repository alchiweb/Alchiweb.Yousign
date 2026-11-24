using Alchiweb.Yousign.Sample.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alchiweb.Yousign.Sample.Features.Yousign;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>

{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(s => s.Id);
    }
}
