using OracleTransaction.Entities.Banks;

namespace OracleTransaction.DataAccess.Interfaces.Banks;

public interface IBank : IRepository<Bank>
{
    ValueTask<Bank?> GetByBankName(string BankName);
}
