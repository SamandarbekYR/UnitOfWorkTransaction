using Microsoft.EntityFrameworkCore;
using OracleTransaction.BusinessLogic.DTOs.Users;
using OracleTransaction.BusinessLogic.Interfaces;
using OracleTransaction.DataAccess.Interfaces;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.BusinessLogic.Services
{
    public class UsersCardService : IUserCardService
    {
        private IUnitOfWork _unitOfWork;

        public UsersCardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Add(AddUserCardDto userCardDto)
        {
            UserCard userCard = new UserCard();
            userCard.UserId = userCardDto.UserId;
            userCard.CardNumber = userCardDto.CardNumber;
            userCard.Name = userCardDto.Name;
            userCard.Balance = userCardDto.Balance;
            userCard.Users = null;

            _unitOfWork.UsersCards.Add(userCard);
            return await _unitOfWork.SaveChangesAsync();
        }

        public List<UserCard> GetAll()
        => _unitOfWork.UsersCards.SelectedAll().AsNoTracking().ToList();
    }
}
