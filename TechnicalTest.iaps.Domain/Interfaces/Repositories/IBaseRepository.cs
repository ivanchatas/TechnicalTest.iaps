using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace TechnicalTest.iaps.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        Task<IQueryable<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
