using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Create(TEntity entity);
        TEntity FindById(Guid id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        int Remove(TEntity entity);
        int Update(TEntity entity);
        IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
