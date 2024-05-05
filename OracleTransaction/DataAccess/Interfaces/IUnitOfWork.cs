using OracleTransaction.DataAccess.Interfaces.Users;

namespace OracleTransaction.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        public IUsers Users { get; set; }
        public IUserCards UsersCards { get; set; }

        public Task<int> SaveChangesAsync();
        public void BeginTrasaction();
        public Task CommitAsync();
        public Task RollBackAsync();
    }
}
