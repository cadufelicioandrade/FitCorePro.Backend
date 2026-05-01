using FitCorePro.Identity.Application.Interfaces;
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using FitCorePro.Training.Planning.Application.Abstractions.Services;
using FitCorePro.Training.Planning.Application.UseCases.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Training
{

    //[Authorize]
    [ApiController]
    [Route("api/training/plano-treino-semanal")]
    public class PlanoTreinoSemanalController : ControllerBase
    {

        private readonly IUserContext _userContext;
        private readonly IPlanoTreinoSemanalService _treinoSemanalService;

        public PlanoTreinoSemanalController(IUserContext userContext, IPlanoTreinoSemanalService treinoSemanalService)
        {
            _userContext = userContext;
            _treinoSemanalService = treinoSemanalService;
        }

        [HttpPost("adicionar-plano-treinamento")]
        public async Task<IActionResult> AdicionarPlanoTreinamento([FromBody] PlanoTreinoSemanalView view)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            string result = await _treinoSemanalService.AdicionarPlanoTreinoSemanalAsync(view, usuarioId);

            return Ok(new ApiMessagemResponse(result));
        }

        [HttpGet("obter-plano-treinamento")]
        public async Task<IActionResult> ObterPlanoTreinamento()
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            var result = await _treinoSemanalService.ObterPlanoTreinoSemanalAsync(usuarioId);

            return Ok();
        }

        [HttpPut("atualizar-plano-treinamento")]
        public async Task<IActionResult> AtualizarPlanoTreinamento([FromBody]PlanoTreinoSemanalView view)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            var result = await _treinoSemanalService.EditarPlanoTreinoSemanalAsync(view, usuarioId);

            return Ok(new ApiMessagemResponse(result));
        }

    }
}
