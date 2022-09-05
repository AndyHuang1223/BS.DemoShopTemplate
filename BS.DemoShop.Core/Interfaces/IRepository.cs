using BS.DemoShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        IQueryable<T> GetAll();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
