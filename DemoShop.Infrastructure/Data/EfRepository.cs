using System.Linq.Expressions;
using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;

namespace DemoShop.Infrastructure.Data;

public class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    public T Add(T entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> AddRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public T Update(T entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public T GetById<TId>(TId id)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetByIdAsync<TId>(TId id)
    {
        throw new NotImplementedException();
    }

    public T FirstOrDefault(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public T SingleOrDefault(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public bool Any(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }
}