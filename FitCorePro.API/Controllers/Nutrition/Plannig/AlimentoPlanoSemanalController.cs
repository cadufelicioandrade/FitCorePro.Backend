using FitCorePro.Identity.Application.Interfaces;
using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Plannig
{
    //[Authorize]
    [ApiController]
    [Route("api/nutritionplanning/alimento-plano-semanal")]
    public class AlimentoPlanoSemanalController : ControllerBase
    {
        private readonly IAlimentoPlanoSemanalService _alimentoPlanoSemanalService;
        private readonly IUserContext _userContext;

        public AlimentoPlanoSemanalController(IAlimentoPlanoSemanalService alimentoPlanoSemanalService, IUserContext userContext)
        {
            _alimentoPlanoSemanalService = alimentoPlanoSemanalService;
            _userContext = userContext;
        }

        [HttpPost("adiciona-range")]
        public async Task<IActionResult> AdicionarRangeAlimentos(List<AlimentoPlanoSemanalRequest> request)
        {
            if(request.Count <=0)
                return BadRequest("Envie pelo menos um alimento na lista.");

            var result = await _alimentoPlanoSemanalService.AdicionarRangeAlimentoPlanoSemanalAsync(request);

            return Ok(new ApiMessagemResponse(result));
        }

        [HttpPut("editar")]
        public async Task<IActionResult> EditarAlimentoPlanoSemanal([FromBody]AlimentoPlanoSemanalRequest request)
        {
            if (request is null)
                return BadRequest("Alimento nulo.");

            var result = await _alimentoPlanoSemanalService.EditarAlimentoPlanoSemanal(request);
            return Ok(new ApiMessagemResponse(result));
        }

        [HttpDelete("remover/{alimentoId}")]
        public async Task<IActionResult> ExcluirAlimentoPlanoSemanal(string alimentoId)
        {
            if (String.IsNullOrEmpty(alimentoId))
                return BadRequest("Envie um id alimento válido!");

            var result = await _alimentoPlanoSemanalService.ExcluirAlimentoPlanoSemanal(alimentoId);

            return Ok(new ApiMessagemResponse(result));
        }
    }
}
