using Microsoft.EntityFrameworkCore.Storage;
using OracleTransaction.DataAccess.Data;
using OracleTransaction.DataAccess.Interfaces;
using OracleTransaction.DataAccess.Interfaces.Banks;
using OracleTransaction.DataAccess.Interfaces.Users;
using OracleTransaction.DataAccess.Repositories.Banks;
using OracleTransaction.DataAccess.Repositories.Users;

namespace OracleTransaction.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IDbContextTransaction _transaction;
    public UnitOfWork(AppDbContext appDb)
    {
        _appDb = appDb;
        Users = new UserRepository(appDb);
        UsersCards = new UserCardsRepository(appDb);
        Banks = new BankRepository(appDb);
    }

    private readonly AppDbContext _appDb;

    public IUsers Users { get; set; }
    public IUserCards UsersCards { get; set; }
    public IBank Banks { get; set; }
    

    public void Dispose()
    {
        if (_transaction != null)
        {
            _transaction.Dispose();
        }
        _appDb.Dispose();
    }

    public void BeginTrasaction()
    {
        _transaction = _appDb.Database.BeginTransaction();
    }

    public async Task CommitAsync()
    {
        await _appDb.SaveChangesAsync();
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
        }
    }

    public async Task RollBackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
        }
    }

    public Task<int> SaveChangesAsync()
    => _appDb.SaveChangesAsync();
}
