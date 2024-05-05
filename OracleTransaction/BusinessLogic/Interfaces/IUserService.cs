using OracleTransaction.BusinessLogic.DTOs.Users;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<int> Add(AddUserDto dto);
        List<User?> GetAll();
    }
}
