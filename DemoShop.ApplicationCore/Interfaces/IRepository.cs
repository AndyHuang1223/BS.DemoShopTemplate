using System.Linq.Expressions;
using DemoShop.ApplicationCore.Entities;

namespace DemoShop.ApplicationCore.Interfaces;

public interface IRepository<T> : IAsyncRepository<T> where T : BaseEntity
{
    T Add(T entity);
    IEnumerable<T> AddRange(IEnumerable<T> entities);
    T Update(T entity);
    IEnumerable<T> UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    T GetById<TId>(TId id);
    Task<T> GetByIdAsync<TId>(TId id);
    T FirstOrDefault(Expression<Func<T, bool>> expression);
    T SingleOrDefault(Expression<Func<T, bool>> expression);
    List<T> List(Expression<Func<T, bool>> expression);
    List<T> List();
}