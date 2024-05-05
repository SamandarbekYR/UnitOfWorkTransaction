using Microsoft.EntityFrameworkCore;
using OracleTransaction.DataAccess.Data;
using OracleTransaction.DataAccess.Interfaces.Users;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.DataAccess.Repositories.Users
{
    public class UserRepository : Repository<User>, IUsers
    {
        private AppDbContext _appDb;

        public UserRepository(AppDbContext appDb)
            : base(appDb)
        {
            _appDb = appDb;
        }

        public async ValueTask UpdatePhoneBalanceAsync(string receiverPhoneNumber, double sendPrice)
        {
            var user = await _appDb.Users.FirstOrDefaultAsync(u => u.PhoneNumber == receiverPhoneNumber);
            
            if (user != null)
            {
                user.Balance = user.Balance + sendPrice;
                _appDb.Users.Update(user);
            }
        }
    }
}
