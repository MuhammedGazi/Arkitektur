
namespace Arkitektur.DataAccess.UOW
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
