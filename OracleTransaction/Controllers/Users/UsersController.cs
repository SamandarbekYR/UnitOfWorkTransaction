using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OracleTransaction.BusinessLogic.DTOs.Users;
using OracleTransaction.BusinessLogic.Interfaces;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddUserDto userDto)
        => Ok(await _userService.Add(userDto));

        [HttpGet]
        public IActionResult GetAll()
        => Ok(_userService.GetAll());
    }
}
