using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using FitCorePro.Training.Planning.Application.Abstractions.Services;
using FitCorePro.Training.Planning.Application.UseCases.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace FitCorePro.API.Controllers.Training
{
    //[Authorize]
    [ApiController]
    [Route("api/training/exercicio")]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioService _exercicioService;

        public ExercicioController(IExercicioService exercicioService)
        {
            _exercicioService = exercicioService;
        }

        [HttpPost("adicionar-exercicio")]
        public async Task<IActionResult> AdicionarExercicio([FromBody] ExercicioView view)
        {
            if (view == null)
                return BadRequest("Exercício inválido.");

            var result = await _exercicioService.AdicionarExercicioAsync(view);


            return Ok(result);
        }

        [HttpPut("editar-exercicio")]
        public async Task<IActionResult> EditarExercicio([FromBody] ExercicioView view)
        {
            if (view is null)
                return BadRequest(("Exercício inválido."));

            var result = await _exercicioService.EditarExercicioAsync(view);

            return Ok(result);
        }

        [HttpDelete("excluir-exercicio/{exercicioId}")]
        public async Task<IActionResult> ExcluirExercicio(string exercicioId)
        {
            if (String.IsNullOrEmpty(exercicioId))
                return BadRequest("Identificador exercício inválido.");

            var result = await _exercicioService.ExcluirExercicioAsync(exercicioId);

            return Ok(new ApiMessagemResponse(result));
        }
    }
}
