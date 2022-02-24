using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetCredit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetRates(decimal creditValue)
        {
            return Ok();
        }
    }
}
