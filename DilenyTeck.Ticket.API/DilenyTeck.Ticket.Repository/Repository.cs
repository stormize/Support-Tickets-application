using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DilenyTeck.Ticket.Repository
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
          where TEntity : class where TContext : DbContext
    {
        readonly DbSet<TEntity> dbSet;
        private readonly TContext context;

        public Repository(TContext context)
        {
            dbSet = context.Set<TEntity>();
            this.context = context;
        }
        public async virtual Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await Task.FromResult(query);
        }
        public abstract Task<TEntity> GetByIdAsync(object id, string includeProperties = null);
        public virtual async Task<TEntity> CreateOnDbAsync(TEntity entity)
        {
            TEntity result = await CreateAsync(entity);
            await SaveChangesAsync();
            return result;
        }
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var dbChangeTracker = await dbSet.AddAsync(entity);
            var x = dbChangeTracker.State == EntityState.Added ? dbChangeTracker.Entity : null;
            return dbChangeTracker.Entity;
        }
        public virtual async Task CreateRangeAsync(params TEntity[] entities)
        {
            await dbSet.AddRangeAsync(entities);
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            return await Task.Run(() =>
            {
                var dbChangeTracker = dbSet.Update(entityToUpdate);
                return dbChangeTracker.State == EntityState.Modified ? dbChangeTracker.Entity : null;
            });
        }
        public virtual async Task<bool> DeleteAsync(object id)
        {
            TEntity entityToDelete = await GetByIdAsync(id);
            if (entityToDelete != null)
            {
                dbSet.Remove(entityToDelete);
                //SaveChangesAsync(); dont add it  use SaveChangesAsync() in service
                return true;
            }
            return false;
        }
        public virtual async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
