using FitCorePro.Nutrition.Planning.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Domain.Repositories
{
    public interface IPlanoSemanalRepository
    {
        Task<PlanoSemanal?> GetPlanoByUsuarioIdAsync(string usuarioId);
    }
}
