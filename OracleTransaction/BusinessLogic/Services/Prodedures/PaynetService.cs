using OracleTransaction.BusinessLogic.Interfaces.Prosedures;
using OracleTransaction.DataAccess.Interfaces;
using OracleTransaction.Entities.Banks;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.BusinessLogic.Services.Prodedures;

public class PaynetService : IPaynet
{
    private const double MIN_PAYMENT = 5;
    private const double MAX_PAYMENT = 100000;
    private const double PERCENT_PAYMENT = 0.5;
    private IUnitOfWork _unitOfWork;

    public PaynetService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async ValueTask Paynet(string senderCardNumber, string receiverPhoneNumber, double sendPrice, string bankName)
    {
        try
        {
            _unitOfWork.BeginTrasaction();

            UserCard? userCard = await _unitOfWork.UsersCards.GetByCardNumber(senderCardNumber);

            if (userCard is null)
            {
                throw new Exception("Invalid card number");
            }

            User? user = await _unitOfWork.Users.GetByPhoneNumber(receiverPhoneNumber);

            if (user is null)
            {
                throw new Exception("Invalid phone number");
            }

            Bank? bank = await _unitOfWork.Banks.GetByBankName(bankName);

            if (bank is null)
            {
                throw new Exception("Invalid bank name");
            }

            if(userCard.Balance < sendPrice + MIN_PAYMENT * sendPrice / 100)
            {
                throw new Exception("Your card does not have enough funds");
            }

            if(sendPrice > MAX_PAYMENT)
            {
                throw new Exception("Max amount exceeded");
            }

            userCard.Balance = userCard.Balance - (sendPrice + PERCENT_PAYMENT * sendPrice / 100);
            _unitOfWork.UsersCards.Update(userCard);

            user.Balance = user.Balance + sendPrice;
            _unitOfWork.Users.Update(user);

            bank.Balance = bank.Balance + sendPrice * PERCENT_PAYMENT /100 ;
            _unitOfWork.Banks.Update(bank);

            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollBackAsync();
            throw new Exception($"Exception {ex}");
        }
    }   
}
