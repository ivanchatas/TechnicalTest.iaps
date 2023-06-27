namespace TechnicalTest.iaps.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<T> Repository<T>() where T : class;

        Task<int> Commit();

        Task Rollback();
    }
}
