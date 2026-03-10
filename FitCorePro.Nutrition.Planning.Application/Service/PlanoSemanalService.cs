using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById;
using FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById.Response;

namespace FitCorePro.Nutrition.Planning.Application.Service
{
    public class PlanoSemanalService : IPlanoSemanalService
    {
        private readonly GetPlanoSemanalByUsuarioIdHandler _handler;
        public PlanoSemanalService(GetPlanoSemanalByUsuarioIdHandler handler)
        {
            _handler = handler;
        }

        public async Task<PlanoSemanalResponse?> GetByUsuarioIdAsync(string usuarioId)
        {
            var query = new GetPlanoSemanalByUsuarioIdQuery(usuarioId);
            return await _handler.Handle(query);
        }
    }
}
