using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OracleTransaction.BusinessLogic.DTOs.Users;
using OracleTransaction.BusinessLogic.Interfaces;

namespace OracleTransaction.Controllers.Users;

[Route("api/userscard")]
[ApiController]
public class UsersCardController : ControllerBase
{
    private IUserCardService _cardService;

    public UsersCardController(IUserCardService userCard)
    {
        _cardService = userCard;
    }

    [HttpGet]
    public IActionResult GetAll()
    => Ok(_cardService.GetAll());

    [HttpPost]
    public async Task<IActionResult> Add(AddUserCardDto cardDto)
    => Ok(await _cardService.Add(cardDto));  
}
