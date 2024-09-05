using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace DemoShop.Infrastructure.Data;

public class EfUnitOfWorkByDictionary : IUnitOfWork
{
    private readonly BSDemoShopContext _context;
    private readonly Dictionary<Type, object> _repositories;
    private IDbContextTransaction _transaction;

    public EfUnitOfWorkByDictionary(BSDemoShopContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new EfRepository<TEntity>(_context);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
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