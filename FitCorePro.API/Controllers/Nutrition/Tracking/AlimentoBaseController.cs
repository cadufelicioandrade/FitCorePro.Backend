using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Tracking
{
    [Authorize]
    [ApiController]
    [Route("api/tracking/alimento-base")]
    public class AlimentoBaseController : ControllerBase
    {
        private readonly IAlimentoBaseService _service;

        public AlimentoBaseController(IAlimentoBaseService service)
        {
            _service = service;
        }

        [HttpGet("obter-todos")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }
    }
}
