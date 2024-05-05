using Microsoft.EntityFrameworkCore;
using OracleTransaction.DataAccess.Data;
using OracleTransaction.DataAccess.Interfaces.Users;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.DataAccess.Repositories.Users;

public class UserCardsRepository : Repository<UserCard>, IUserCards
{
    private AppDbContext _appDb;
    public UserCardsRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }

    public async ValueTask<UserCard?> GetByCardNumber(string CardNumber)
    => await _appDb.UserCards.FirstOrDefaultAsync(e => e.CardNumber == CardNumber)!;
}
