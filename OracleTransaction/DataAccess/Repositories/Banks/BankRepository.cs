using OracleTransaction.DataAccess.Data;
using OracleTransaction.DataAccess.Interfaces.Banks;
using OracleTransaction.Entities.Banks;

namespace OracleTransaction.DataAccess.Repositories.Banks;

public class BankRepository : Repository<Bank>, IBank
{
    public BankRepository(AppDbContext appDb) : base(appDb)
    { }
}
