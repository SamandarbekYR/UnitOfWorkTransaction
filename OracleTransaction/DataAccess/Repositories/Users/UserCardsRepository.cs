using OracleTransaction.DataAccess.Data;
using OracleTransaction.DataAccess.Interfaces.Users;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.DataAccess.Repositories.Users;

public class UserCardsRepository : Repository<UserCard>, IUserCards
{
    public UserCardsRepository(AppDbContext appDb) : base(appDb)
    { }
}
