using DemoShop.ApplicationCore.Entities;

namespace DemoShop.ApplicationCore.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    Task BeginAsync();
    Task CommitAsync();
    Task RollbackAsync();
}