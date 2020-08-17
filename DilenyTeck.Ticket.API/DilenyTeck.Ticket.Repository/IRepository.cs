using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DilenyTeck.Ticket.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetAsync(
             Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByIdAsync(object id, string includeProperties = null);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> CreateOnDbAsync(TEntity entity);
        Task CreateRangeAsync(params TEntity[] entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(object id);
        Task<int> SaveChangesAsync();
    }
}
