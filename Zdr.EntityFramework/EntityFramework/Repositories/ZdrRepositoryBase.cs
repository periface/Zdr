using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Zdr.EntityFramework.Repositories
{
    public abstract class ZdrRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ZdrDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ZdrRepositoryBase(IDbContextProvider<ZdrDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ZdrRepositoryBase<TEntity> : ZdrRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ZdrRepositoryBase(IDbContextProvider<ZdrDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
