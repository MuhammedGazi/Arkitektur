using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetQueryable();
        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
