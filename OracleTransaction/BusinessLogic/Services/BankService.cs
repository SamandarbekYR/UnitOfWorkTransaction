using Microsoft.EntityFrameworkCore;
using OracleTransaction.BusinessLogic.DTOs;
using OracleTransaction.BusinessLogic.Interfaces;
using OracleTransaction.DataAccess.Interfaces;
using OracleTransaction.Entities.Banks;

namespace OracleTransaction.BusinessLogic.Services;

public class BankService : IBankService
{
    private IUnitOfWork _unitOfWork;

    public BankService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Add(AddBankDto addBankDto)
    {
        Bank bank = new Bank();
        bank.Name = addBankDto.Name;
        bank.Balance = addBankDto.Balance;
        _unitOfWork.Banks.Add(bank);

        return await _unitOfWork.SaveChangesAsync();
    }

    public List<Bank> GetAll()
    => _unitOfWork.Banks.SelectedAll().AsNoTracking().ToList();
}
