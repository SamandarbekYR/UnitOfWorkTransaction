using OracleTransaction.Entities.Users;

namespace OracleTransaction.DataAccess.Interfaces.Users
{
    public interface IUsers : IRepository<User>
    {
        ValueTask UpdatePhoneBalanceAsync(string receiverPhoneNumber, double sendPrice);
    }
}
