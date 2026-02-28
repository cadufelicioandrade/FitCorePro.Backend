using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;
using FitCorePro.Nutrition.Planning.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Repositories
{
    public class PlanoSemanaRepositories : IPlanoSemanalRepository
    {
        private readonly PlanningDbContext _context;

        public PlanoSemanaRepositories(PlanningDbContext context)
        {
            _context = context;
        }

        public Task<PlanoSemanal?> GetPlanoByUsuarioIdAsync(string usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
