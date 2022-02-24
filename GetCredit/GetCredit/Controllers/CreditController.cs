using GetCredit.Dtos;
using GetCredit.Services;
using Microsoft.AspNetCore.Mvc;

namespace GetCredit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly CreditService _creditService;

        public CreditController(CreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpPost]
        public IActionResult GetRates(CreditRequestDto creditRequest)
        {
            try
            {
                CreditDetailsDto offer = _creditService.GetOffer(creditRequest);
                return Ok(offer);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
