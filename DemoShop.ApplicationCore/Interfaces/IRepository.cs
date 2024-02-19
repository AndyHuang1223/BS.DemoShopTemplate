using System.Linq.Expressions;
using DemoShop.ApplicationCore.Entities;

namespace DemoShop.ApplicationCore.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    T Add(T entity);
    IEnumerable<T> AddRange(IEnumerable<T> entities);
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities); 
    T Update(T entity);
    IEnumerable<T> UpdateRange(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    T GetById<TId>(TId id);
    Task<T> GetByIdAsync<TId>(TId id);
    T FirstOrDefault(Expression<Func<T, bool>> expression);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
    T SingleOrDefault(Expression<Func<T, bool>> expression);
    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression);
    bool Any(Expression<Func<T, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    Task<List<T>> ListAsync();
    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
}