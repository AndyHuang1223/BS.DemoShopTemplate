using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace DemoShop.Infrastructure.Data;

public class EfUnitOfWorkByServiceProvider : IUnitOfWork
{
    private readonly BSDemoShopContext _context;
    private readonly IServiceProvider _serviceProvider;
    private IDbContextTransaction _transaction;

    public EfUnitOfWorkByServiceProvider(BSDemoShopContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
    {
        return _serviceProvider.GetRequiredService<IRepository<TEntity>>();
    }

    public async Task BeginAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }
}