using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao.Request;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Plannig
{
    [ApiController]
    [Route("api/nutritionplanning/plano-semanal")]
    public class RefeicaoPlanoSemanalController : ControllerBase
    {
        [HttpPost("refeicao")]
        public async Task<IActionResult> AdicionarRefeicao([FromBody] CriaRefeicaoRequest criaRefeicaoRequest)
        {

            return Ok();
        }

    }
}
