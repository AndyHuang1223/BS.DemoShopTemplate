using System.Linq.Expressions;
using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoShop.Infrastructure.Data;

public class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly BSDemoShopContext DbContext;
    protected readonly DbSet<T> DbSet;

    public EfRepository(BSDemoShopContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<T>();
    }


    public T Add(T entity)
    {
        DbSet.Add(entity);
        DbContext.SaveChanges();
        return entity;
    }

    public IEnumerable<T> AddRange(IEnumerable<T> entities)
    {
        DbSet.AddRange(entities);
        DbContext.SaveChanges();
        return entities;
    }

    public async Task<T> AddAsync(T entity)
    {
        DbSet.Add(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        DbSet.AddRange(entities);
        await DbContext.SaveChangesAsync();
        return entities;
    }

    public T Update(T entity)
    {
        DbSet.Update(entity);
        DbContext.SaveChanges();
        return entity;
    }

    public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
    {
        DbSet.UpdateRange(entities);
        DbContext.SaveChanges();
        return entities;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
    {
        DbSet.UpdateRange(entities);
        await DbContext.SaveChangesAsync();
        return entities;
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
        DbContext.SaveChanges();
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        DbSet.RemoveRange(entities);
        DbContext.SaveChanges();
    }

    public async Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        await DbContext.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        DbSet.RemoveRange(entities);
        await DbContext.SaveChangesAsync();
    }


    public T GetById<TId>(TId id)
    {
        return DbSet.Find(new object[] { id });
    }

    public async Task<T> GetByIdAsync<TId>(TId id)
    {
        return await DbSet.FindAsync(new object[] { id });
    }

    public T FirstOrDefault(Expression<Func<T, bool>> expression)
    {
        return DbSet.FirstOrDefault(expression);
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return await DbSet.FirstOrDefaultAsync(expression);
    }

    public T SingleOrDefault(Expression<Func<T, bool>> expression)
    {
        return DbSet.SingleOrDefault(expression);
    }

    public List<T> List(Expression<Func<T, bool>> expression)
    {
        return DbSet.Where(expression).ToList();
    }

    public List<T> List()
    {
        return DbSet.ToList();
    }

    public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return await DbSet.SingleOrDefaultAsync(expression);
    }

    public bool Any(Expression<Func<T, bool>> expression)
    {
        return DbSet.Any(expression);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await DbSet.AnyAsync(expression);
    }

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        return await DbSet.Where(expression).ToListAsync();
    }

    public async Task<List<T>> ListAsync()
    {
        return await DbSet.ToListAsync();
    }
}