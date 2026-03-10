using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Plannig
{
    [ApiController]
    [Route("api/nutritionplanning/plano-semnal")]
    public class PlanoSemanaController : ControllerBase
    {
        private readonly IPlanoSemanalService _planoSemanalService;

        public PlanoSemanaController(IPlanoSemanalService planoSemanalService)
        {
            _planoSemanalService = planoSemanalService;
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetAllByUsuarioId(string usuarioId)
        {
            var result = await _planoSemanalService.GetByUsuarioIdAsync(usuarioId);

            return Ok(result);
        }
    }
}
