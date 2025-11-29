using Arkitektur.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.DataAccess.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext context) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _table = context.Set<TEntity>();
        public async Task CreateAsync(TEntity entity)
        {
            await context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _table.FindAsync();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _table;
        }

        public void Update(TEntity entity)
        {
            context.Update(entity);
        }
    }
}
