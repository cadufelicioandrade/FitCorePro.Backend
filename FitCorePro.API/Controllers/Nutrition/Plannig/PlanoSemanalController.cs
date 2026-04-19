using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using FitCorePro.Nutrition.Planning.Application.UseCases.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Plannig
{
    [Authorize]
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
            if (String.IsNullOrEmpty(usuarioId))
                return BadRequest(new ApiMessagemResponse("Envie um usuário Id válido!"));

            var result = await _planoSemanalService.GetByUsuarioIdAsync(usuarioId);

            return Ok(result);
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarPlanoSemanal([FromBody] PlanoSemanalRequest request)
        {
            if (request is null)
                return BadRequest(new ApiMessagemResponse("Envie um Plano Semanal Válido!"));

            var result = await _planoSemanalService.AdicionarPlanoSemanalAsync(request);
            return Ok(new ApiMessagemResponse(result));
        }
    }
}
