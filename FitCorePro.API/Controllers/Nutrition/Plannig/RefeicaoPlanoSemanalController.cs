using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao.Request;
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Plannig
{
    [ApiController]
    [Route("api/nutritionplanning/plano-semanal")]
    public class RefeicaoPlanoSemanalController : ControllerBase
    {
        IRefeicaoPlanoSemanalService _service;

        public RefeicaoPlanoSemanalController(IRefeicaoPlanoSemanalService service)
        {
            _service = service;
        }

        [HttpPost("refeicao")]
        public async Task<IActionResult> AdicionarRefeicao([FromBody] CriaRefeicaoRequest criaRefeicaoRequest)
        {
            var result = await _service.AdicionarRefeicaoPlanoSemanalAsync(criaRefeicaoRequest);

            return Ok(result);
        }

        [HttpDelete("delete-refeicao/{refeicaoId}")]
        public async Task<IActionResult> DeleteRefeicao(string refeicaoId)
        {
            var resutl = await _service.RemoverRefeicaoPlanoSemanalAsync(refeicaoId);

            return Ok(new ApiMessagemResponse(resutl));
        }

    }
}
