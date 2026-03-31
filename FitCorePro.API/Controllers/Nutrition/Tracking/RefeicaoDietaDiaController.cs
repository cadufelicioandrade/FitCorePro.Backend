using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Tracking
{
    [ApiController]
    [Route("api/tracking/refeicao-dieta-dia")]
    public class RefeicaoDietaDiaController : ControllerBase
    {
        private readonly IRefeicaoDietaDiaService _service;

        public RefeicaoDietaDiaController(IRefeicaoDietaDiaService service)
        {
            _service = service;
        }

        [HttpPost("adicionar-refeicao")]
        public async Task<IActionResult> AdicionarRefeicao([FromBody] RefeicaoDietaDiaView view)
        {
            var resp = await _service.AdicionarRefeicaoDietaDiaAsync(view);

            return Ok(new ApiMessagemResponse(resp));
        }

        [HttpDelete("excluir-refeicao/{refeicaoId}")]
        public async Task<IActionResult> ExcluirRefeicao(string refeicaoId)
        {
            var resp = await _service.ExcluirRefeicaoDietaDiaAsync(refeicaoId);

            return Ok(new ApiMessagemResponse(resp));
        }

        [HttpPut("atualizar-list-refeicoes")]
        public async Task<IActionResult> AtualizarListaRefeicoes([FromBody] List<RefeicaoDietaDiaView> list)
        {
            var resp = await _service.AtualizarListaRefeicoes(list);

            return Ok(new ApiMessagemResponse(resp));
        }
    }
}
