using Ardalis.Specification.EntityFrameworkCore.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore.Custom;
using Microsoft.EntityFrameworkCore;

namespace Alchiweb.Yousign.Sample.Infrastructure.Data;

// inherit from Ardalis.Specification type

public class EfRepositoryApp<T, TId> : RepositoryBaseOfT<T, TId, AppDbContext>, IRepository<T, TId>
    where T : class, IEntityBase<T, TId>//, IAggregateRoot
    where TId : struct, IEquatable<TId>
{
    public EfRepositoryApp(AppDbContext dbContext)
        : base(dbContext) { }
    public EfRepositoryApp(IDbContextFactory<AppDbContext> dbContextFactory)
        : base(dbContextFactory) { }
    public EfRepositoryApp(IDbContextFactory<AppDbContext> dbContextFactory, AppDbContext dbContext)
        : base(dbContextFactory, dbContext) { }


}

public class EfRepositoryApp<T> :
  EfRepositoryApp<T, Guid>, IRepository<T>
    where T : class, IEntityBase<T, Guid>//, IAggregateRoot
{
    public EfRepositoryApp(AppDbContext dbContext)
    : base(dbContext) { }
    public EfRepositoryApp(IDbContextFactory<AppDbContext> dbContextFactory)
        : base(dbContextFactory) { }
    public EfRepositoryApp(IDbContextFactory<AppDbContext> dbContextFactory, AppDbContext dbContext)
        : base(dbContextFactory, dbContext) { }

}
