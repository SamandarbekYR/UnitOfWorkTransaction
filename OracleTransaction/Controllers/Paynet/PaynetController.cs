using Microsoft.AspNetCore.Mvc;
using OracleTransaction.BusinessLogic.Interfaces.Prosedures;
using OracleTransaction.DataAccess.Interfaces;
using OracleTransaction.Entities.Users;

namespace OracleTransaction.Controllers.Paynet
{
    [Route("api/paynet")]
    [ApiController]
    public class PaynetController : ControllerBase
    {
        private IPaynet _paynet;
        private IUnitOfWork _unitOfWork;

        public PaynetController(IPaynet paynet, IUnitOfWork unitOfWork)
        {
            _paynet = paynet;
            _unitOfWork = unitOfWork;
        }
        [HttpPut]
        public async Task<IActionResult> Payment(
                                                    [FromQuery] string senderCardNumber,
                                                    [FromQuery] string receiverPhoneNumber,
                                                    [FromQuery] double sendPrice,
                                                    [FromQuery] string bankName
                                                )
        {
            try
            {
                await _paynet.Paynet(senderCardNumber, receiverPhoneNumber, sendPrice, bankName);
                return Ok("Payment successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"An error occurred: {ex.Message}"); // Return a generic error message
            }
        }
    }
}
