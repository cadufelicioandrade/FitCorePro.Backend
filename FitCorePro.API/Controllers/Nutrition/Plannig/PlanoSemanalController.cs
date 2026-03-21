using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Plannig
{
    [ApiController]
    [Route("api/nutritionplanning/plano-semanal")]
    public class PlanoSemanalController : ControllerBase
    {
        private readonly IPlanoSemanalService _planoSemanalService;

        public PlanoSemanalController(IPlanoSemanalService planoSemanalService)
        {
            _planoSemanalService = planoSemanalService;
        }

        [HttpGet("obter-todos/{usuarioId}")]
        public async Task<IActionResult> GetAllByUsuarioId(string usuarioId)
        {
            var result = await _planoSemanalService.GetByUsuarioIdAsync(usuarioId);

            return Ok(result);
        }


    }
}
