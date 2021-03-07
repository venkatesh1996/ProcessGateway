using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProcessGateway.Repositories
{
    public interface IBaseRepository<TEntity, TId>
    {
        
        Task<TEntity> InsertAsync(TEntity entity);

        
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

       
        Task<TEntity> GetAsync(TId id);

      
        Task<IEnumerable<TEntity>> GetAllAsync();

       
        Task<TEntity> UpdateAsync(TEntity obj);

      
        Task DeleteFinallyAsync(TEntity obj);
    }
}
