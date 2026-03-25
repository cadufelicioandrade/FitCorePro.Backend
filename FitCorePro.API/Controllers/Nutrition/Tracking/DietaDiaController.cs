using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.UseCases.Response;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Nutrition.Tracking
{
    [ApiController]
    [Route("api/tracking/dieta-dia")]
    public class DietaDiaController : ControllerBase
    {

        private readonly IDietaDiaService _dietaDiaService;

        public DietaDiaController(IDietaDiaService dietaDiaService)
        {
            _dietaDiaService = dietaDiaService;
        }

        [HttpGet("obter-todos")]
        public async Task<IActionResult> GetAll(string usuarioId, DateTime dataDieta) 
        {
            if (String.IsNullOrWhiteSpace(usuarioId))
                return BadRequest(new ApiMessageResponse("Forneça um usuarioId válido."));

            var result = await _dietaDiaService.GetAllAsync(usuarioId, dataDieta);

            return Ok(result);
        }
    }
}
