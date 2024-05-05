using Microsoft.EntityFrameworkCore;
using OracleTransaction.DataAccess.Data;
using OracleTransaction.DataAccess.Interfaces.Banks;
using OracleTransaction.Entities.Banks;

namespace OracleTransaction.DataAccess.Repositories.Banks;

public class BankRepository : Repository<Bank>, IBank
{
    public AppDbContext _appDb;
    public BankRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }

    public async ValueTask<Bank?> GetByBankName(string BankName)
    => await _appDb.Banks.FirstOrDefaultAsync(n => n.Name == BankName);
    
}
