using Alchiweb.Yousign.Sample.Domain;
using Alchiweb.Yousign.Sample.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alchiweb.Yousign.Sample.Infrastructure.Data;

public partial class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext(options), IDataProtectionKeyContext
{
    public DbSet<Signature> Signatures { get; set; } = default!;
    public DbSet<Approver> Approvers { get; set; } = default!;
    public DbSet<Document> Documents { get; set; } = default!;
    public DbSet<Signer> Signers { get; set; } = default!;

    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        //ConfigureIdentityTableNames(modelBuilder);

        ConfigureConcurrencyToken(modelBuilder);

        ConfigureRowVersion(modelBuilder);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
       OnSavingChanges();

//#pragma warning disable NonAsyncEFCoreMethodsUsageAnalyzer
        return base.SaveChanges(acceptAllChangesOnSuccess);
//#pragma warning restore NonAsyncEFCoreMethodsUsageAnalyzer

    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        OnSavingChanges();

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void OnSavingChanges()
    {
        ChangeTracker.DetectChanges();

        foreach (var entry in ChangeTracker.Entries().Where(e => e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted))
        {
            if (entry.Properties.Any(p => p.Metadata.Name == "UpdatedAt"))
                entry.CurrentValues["UpdatedAt"] = DateTimeOffset.UtcNow;
        }

        foreach (var entityEntry in ChangeTracker.Entries().Where(e => e.State is EntityState.Modified or EntityState.Deleted))
        {
            // https://github.com/dotnet/efcore/issues/35443
            if (entityEntry.Properties.Any(p => p.Metadata.Name == "Version") && entityEntry.CurrentValues["Version"] is long currentVersion)
                entityEntry.OriginalValues["Version"] = currentVersion;
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
       configurationBuilder.Conventions.Add(_ => new SqlServerPrimaryKeySequentialGuidDefaultValueConvention());

        configurationBuilder.Properties<decimal>().HavePrecision(18, 3);
        configurationBuilder.Properties<decimal?>().HavePrecision(18, 3);

        base.ConfigureConventions(configurationBuilder);
    }
    /*
    private void ConfigureIdentityTableNames(ModelBuilder builder)
    {
        //builder.Entity<User>()
        //    .ToTable("Users");

        //builder.Entity<Role>()
        //    .ToTable("Roles");

        //builder.Entity<UserRole>()
        //    .ToTable("UserRoles");

        //builder.Entity<RoleClaim>()
        //    .ToTable("RoleClaims");

        //builder.Entity<UserClaim>()
        //    .ToTable("UserClaims");

        //builder.Entity<UserLogin>()
        //    .ToTable("UserLogins");

        //builder.Entity<UserToken>()
        //    .ToTable("UserTokens");
    }
    */

    private void ConfigureConcurrencyToken(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {

            foreach (var property in entityType.GetProperties()
                .Where(p => p.Name is "Version" && p.PropertyInfo?.PropertyType == typeof(long)))
            {
#pragma warning disable EF1001 // Internal EF Core API usage.
                var builder = new PropertyBuilder(property);
#pragma warning restore EF1001 // Internal EF Core API usage.
                builder.IsConcurrencyToken();
            }
        }
    }

    private void ConfigureRowVersion(ModelBuilder modelBuilder)
    {

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {

            foreach (var property in entityType.GetProperties()
                .Where(p => p.Name is "Version" && p.PropertyInfo?.PropertyType == typeof(long)))
            {
#pragma warning disable EF1001 // Internal EF Core API usage.
                var builder = new PropertyBuilder(property);
#pragma warning restore EF1001 // Internal EF Core API usage.

                builder.IsRowVersion();

                builder.HasConversion<byte[]>();
            }
        }
    }

    public static readonly bool IsEmbeddingEnabled = false;
}
