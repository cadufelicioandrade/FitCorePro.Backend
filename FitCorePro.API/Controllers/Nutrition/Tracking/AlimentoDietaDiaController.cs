using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Tracking
{
    [ApiController]
    [Route("api/tracking/aliemnto-dieta-dia")]
    public class AlimentoDietaDiaController : ControllerBase
    {
        private readonly IAlimentoDietaDiaService _service;

        public AlimentoDietaDiaController(IAlimentoDietaDiaService service)
        {
            _service = service;
        }

        [HttpPost("adicionar-alimento-dieta-dia")]
        public async Task<IActionResult> AdicionarAlimento([FromBody] AlimentoDietaDiaView view)
        {
            var result = _service.AdicionarAsync(view);
            return Ok(result);
        }

        [HttpPut("editar-alimento-dieta-dia")]
        public async Task<IActionResult> EditarAlimento([FromBody] AlimentoDietaDiaView view)
        {
            var result = _service.EditarAsync(view);

            return Ok(result);
        }
    }
}
