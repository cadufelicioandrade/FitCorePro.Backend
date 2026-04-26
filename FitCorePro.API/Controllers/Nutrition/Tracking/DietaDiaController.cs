using FitCorePro.Identity.Application.Interfaces;
using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.UseCases.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FitCorePro.API.Controllers.Nutrition.Tracking
{
    //[Authorize]
    [ApiController]
    [Route("api/tracking/dieta-dia")]
    public class DietaDiaController : ControllerBase
    {

        private readonly IDietaDiaService _dietaDiaService;
        private readonly IUserContext _userContext;

        public DietaDiaController(
            IDietaDiaService dietaDiaService, 
            IUserContext userContext)
        {
            _dietaDiaService = dietaDiaService;
            _userContext = userContext;
        }

        [HttpGet("obter-todos")]
        public async Task<IActionResult> GetAll([FromQuery] DateOnly dataDieta)
        {
            var usuarioId = _userContext.GetUserId();

            //if (String.IsNullOrWhiteSpace(usuarioId))
            //    return Unauthorized();

            var result = await _dietaDiaService.GetAllAsync(usuarioId, dataDieta);

            return Ok(result);
        }
    }
}
