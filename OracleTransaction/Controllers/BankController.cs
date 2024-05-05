using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OracleTransaction.BusinessLogic.DTOs;
using OracleTransaction.BusinessLogic.Interfaces;

namespace OracleTransaction.Controllers;

[Route("api/bank")]
[ApiController]
public class BankController : ControllerBase
{
    private IBankService _bankService;

    public BankController(IBankService bankService)
    {
        _bankService = bankService;
    }
    [HttpGet]
    public IActionResult GetAll() 
    => Ok( _bankService.GetAll());

    [HttpPost]
    public async Task<IActionResult> Add(AddBankDto addBankDto)
    => Ok( await _bankService.Add(addBankDto));
}
