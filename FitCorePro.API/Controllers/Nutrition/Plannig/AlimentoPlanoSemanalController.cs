using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Plannig
{
    [ApiController]
    [Route("api/nutritionplanning/alimento-plano-semanal")]
    public class AlimentoPlanoSemanalController : ControllerBase
    {
        private readonly IAlimentoPlanoSemanalService _alimentoPlanoSemanalService;

        public AlimentoPlanoSemanalController(IAlimentoPlanoSemanalService alimentoPlanoSemanalService)
        {
            _alimentoPlanoSemanalService = alimentoPlanoSemanalService;
        }

        [HttpPost("adiciona-range")]
        public async Task<IActionResult> AdicionarRangeAlimentos(List<AlimentoPlanoSemanalRequest> request)
        {
            var result = await _alimentoPlanoSemanalService.AdicionarRangeAlimentoPlanoSemanalAsync(request);

            return Ok(new ApiMessagemResponse(result));
        }


    }
}
