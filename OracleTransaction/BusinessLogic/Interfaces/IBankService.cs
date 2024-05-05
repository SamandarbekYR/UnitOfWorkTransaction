using OracleTransaction.BusinessLogic.DTOs;
using OracleTransaction.Entities.Banks;

namespace OracleTransaction.BusinessLogic.Interfaces;

public interface IBankService
{
    List<Bank> GetAll();
    Task<int> Add(AddBankDto addBankDto);
}