using FitCorePro.Identity.Application.Interfaces;
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
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

        public PlanoTreinoSemanalController(IUserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet("obter-plano-treinamento")]
        public async Task<IActionResult> ObterPlanoTreinamento()
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            return Ok();
        }

        [HttpPut("atualizar-plano-treinamento")]
        public async Task<IActionResult> AtualizarPlanoTreinamento([FromBody] PlanoTreinoSemanalView planoTreinoSemanal)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            return Ok();
        }

    }
}
