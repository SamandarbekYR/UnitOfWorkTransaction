using OracleTransaction.Entities.Users;

namespace OracleTransaction.DataAccess.Interfaces.Users;

public interface IUserCards : IRepository<UserCard>
{
    ValueTask<UserCard?> GetByCardNumber(string CardNumber);
}
