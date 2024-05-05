using Microsoft.EntityFrameworkCore;
using OracleTransaction.BusinessLogic.DTOs.Users;
using OracleTransaction.BusinessLogic.Interfaces;
using OracleTransaction.DataAccess.Interfaces;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Add(AddUserDto dto)
        {
            User user = new User();
            user.Name = dto.Name;
            user.PhoneNumber = dto.PhoneNumber;
            user.Balance = dto.Balance;
            _unitOfWork.Users.Add(user);
            return await _unitOfWork.SaveChangesAsync();
        }

        public List<User?> GetAll()
        => _unitOfWork.Users.SelectedAll().AsNoTracking().ToList()!;
            
        
        
    }
}
