using FitCorePro.Identity.Application.Interfaces;
using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using FitCorePro.Nutrition.Planning.Application.UseCases.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Plannig
{
    //[Authorize]
    [ApiController]
    [Route("api/nutritionplanning/plano-semanal")]
    public class PlanoSemanalController : ControllerBase
    {
        private readonly IPlanoSemanalService _planoSemanalService;
        private readonly IUserContext _userContext;

        public PlanoSemanalController(
            IPlanoSemanalService planoSemanalService,
            IUserContext userContext)
        {
            _planoSemanalService = planoSemanalService;
            _userContext = userContext;
        }

        [HttpGet("obter-todos")]
        public async Task<IActionResult> GetAllByUsuarioId()
        {

            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrEmpty(usuarioId))
            //    return Unauthorized();

            var result = await _planoSemanalService.GetByUsuarioIdAsync(usuarioId);

            return Ok(result);
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarPlanoSemanal([FromBody] PlanoSemanalRequest request)
        {
            if (request is null)
                return BadRequest(new ApiMessagemResponse("Envie um Plano Semanal Válido!"));

            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrEmpty(usuarioId))
            //    return Unauthorized();

            var result = await _planoSemanalService.AdicionarPlanoSemanalAsync(usuarioId, request);
            return Ok(new ApiMessagemResponse(result));
        }
    }
}
