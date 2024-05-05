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

        public async ValueTask<User?> GetByPhoneNumber(string receiverPhoneNumber)
        => await _appDb.Users.FirstOrDefaultAsync(x => x.PhoneNumber == receiverPhoneNumber);
    }
}
