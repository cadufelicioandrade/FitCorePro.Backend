using FitCorePro.Identity.Application.Interfaces;
using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Plannig
{
    //[Authorize]
    [ApiController]
    [Route("api/nutritionplanning/plano-semanal")]
    public class RefeicaoPlanoSemanalController : ControllerBase
    {
        IRefeicaoPlanoSemanalService _service;
        private readonly IUserContext _userContext;

        public RefeicaoPlanoSemanalController(IRefeicaoPlanoSemanalService service, IUserContext userContext)
        {
            _service = service;
            _userContext = userContext;
        }

        [HttpPost("refeicao")]
        public async Task<IActionResult> AdicionarRefeicao([FromBody] CriaRefeicaoRequest criaRefeicaoRequest)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            var result = await _service.AdicionarRefeicaoPlanoSemanalAsync(usuarioId, criaRefeicaoRequest);

            return Ok(new ApiMessagemResponse(result));
        }

        [HttpDelete("delete-refeicao/{refeicaoId}")]
        public async Task<IActionResult> DeleteRefeicao(string refeicaoId)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();


            var resutl = await _service.RemoverRefeicaoPlanoSemanalAsync(usuarioId, refeicaoId);

            return Ok(new ApiMessagemResponse(resutl));
        }

    }
}
