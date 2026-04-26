using FitCorePro.Identity.Application.Interfaces;
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Tracking
{
    //[Authorize]
    [ApiController]
    [Route("api/tracking/refeicao-dieta-dia")]
    public class RefeicaoDietaDiaController : ControllerBase
    {
        private readonly IRefeicaoDietaDiaService _service;
        private readonly IUserContext _userContext;

        public RefeicaoDietaDiaController(IRefeicaoDietaDiaService service, IUserContext userContext)
        {
            _service = service;
            _userContext = userContext;
        }

        [HttpPost("adicionar-refeicao")]
        public async Task<IActionResult> AdicionarRefeicao([FromBody] RefeicaoDietaDiaView view)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            var resp = await _service.AdicionarRefeicaoDietaDiaAsync(usuarioId, view);

            return Ok(new ApiMessagemResponse(resp));
        }

        [HttpDelete("excluir-refeicao/{refeicaoId}")]
        public async Task<IActionResult> ExcluirRefeicao(string refeicaoId)
        {

            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            var resp = await _service.ExcluirRefeicaoDietaDiaAsync(usuarioId, refeicaoId);

            return Ok(new ApiMessagemResponse(resp));
        }

        [HttpPut("atualizar-list-refeicoes")]
        public async Task<IActionResult> AtualizarListaRefeicoes([FromBody] List<RefeicaoDietaDiaView> list)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            var resp = await _service.AtualizarListaRefeicoes(usuarioId, list);

            return Ok(new ApiMessagemResponse(resp));
        }

        [HttpDelete("excluir-refeicoes-data/{dataDia}")]
        public async Task<IActionResult> ExcluirRefeicoesPorData(DateTime dataDia)
        {

            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            var resp = await _service.ExcluirRefeicoesPorDataAsync(usuarioId, DateOnly.FromDateTime(dataDia));

            return Ok(new ApiMessagemResponse(resp));
        }
    }
}
