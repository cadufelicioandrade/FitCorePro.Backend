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
    [Route("api/tracking/aliemnto-dieta-dia")]
    public class AlimentoDietaDiaController : ControllerBase
    {
        private readonly IAlimentoDietaDiaService _service;
        private readonly IUserContext _userContext;

        public AlimentoDietaDiaController(IAlimentoDietaDiaService service, IUserContext userContext)
        {
            _service = service;
            _userContext = userContext;
        }

        [HttpPost("adicionar-alimento-dieta-dia")]
        public async Task<IActionResult> AdicionarAlimento([FromBody] AlimentoDietaDiaView view)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            var result = await _service.AdicionarAsync(usuarioId, view);
            return Ok(new ApiMessagemResponse(result));
        }

        [HttpPut("editar-alimento-dieta-dia")]
        public async Task<IActionResult> EditarAlimento([FromBody] AlimentoDietaDiaView view)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            var result = await _service.EditarAsync(usuarioId, view);

            return Ok(new ApiMessagemResponse(result));
        }

        [HttpDelete("excluir-alimento-dieta-dia/{alimentoDietaDiaId}")]
        public async Task<IActionResult> ExcluirAlimento(string alimentoDietaDiaId)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            string result = await _service.ExcluirAsync(usuarioId, alimentoDietaDiaId);
            return Ok(new ApiMessagemResponse(result));
        }
    }
}
