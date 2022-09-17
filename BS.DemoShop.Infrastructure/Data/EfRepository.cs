using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly BSDemoShopContext DbContext;

        public EfRepository(BSDemoShopContext dbContext)
        {
            DbContext = dbContext;
        }


        public T Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().AddRange(entities);
            DbContext.SaveChanges();
            return entities;
        }

        public async Task<T> AddAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            DbContext.Set<T>().AddRange(entities);
            await DbContext.SaveChangesAsync();
            return entities;
        }

        public T Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().UpdateRange(entities);
            DbContext.SaveChanges();
            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            DbContext.Set<T>().UpdateRange(entities);
            await DbContext.SaveChangesAsync();
            return entities;
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            DbContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
            DbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
            await DbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public IQueryable<T> GetAllReadOnly()
        {
            return DbContext.Set<T>().AsNoTracking();
        }

        public T GetById<TId>(TId id)
        {
            return DbContext.Set<T>().Find(new object[] { id });
        }

        public async Task<T> GetByIdAsync<TId>(TId id)
        {
            return await DbContext.Set<T>().FindAsync(new object[] { id });
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().FirstOrDefault(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().SingleOrDefault(expression);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await DbContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Any(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await DbContext.Set<T>().AnyAsync(expression);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression);
        }
    }
}