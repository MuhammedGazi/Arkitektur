namespace Arkitektur.DataAccess.UOW
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
