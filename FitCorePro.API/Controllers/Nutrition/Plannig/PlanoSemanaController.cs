using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Plannig
{
    [ApiController]
    [Route("api/nutritionplanning/plano-semnal")]
    public class PlanoSemanaController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
