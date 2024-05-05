using OracleTransaction.BusinessLogic.DTOs.Users;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.BusinessLogic.Interfaces
{
    public interface IUserCardService
    {
        Task<int> Add(AddUserCardDto userCardDto);
        List<UserCard> GetAll();
    }
}
