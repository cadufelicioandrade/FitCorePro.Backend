namespace FitCorePro.Nutrition.Tracking.Application.UseCases.Queries
{
    public sealed record class DietaDiaGetAllQuery(string usuarioId, DateOnly dataDieta);
}
