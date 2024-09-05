using System.Linq.Expressions;
using DemoShop.ApplicationCore.Entities;

namespace DemoShop.ApplicationCore.Interfaces;

public interface IAsyncRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
    Task<List<T>> ListAsync();
}