using System.Collections;
using TechnicalTest.iaps.Domain.Interfaces.Repositories;
using TechnicalTest.iaps.Infrastructure.Context;

namespace TechnicalTest.iaps.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechnicalTestContext _dbContext;
        private bool disposed;
        private Hashtable _repositories;

        public UnitOfWork(TechnicalTestContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);
                _repositories.Add(type, repositoryInstance);
            }

            return (IBaseRepository<TEntity>)_repositories[type];
        }

        public async Task<int> Commit()
            => await _dbContext.SaveChangesAsync();

        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
    }
}
