using FitCorePro.Nutrition.Planning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Persistence;

public sealed class PlanningDbContext : DbContext
{
    public PlanningDbContext(DbContextOptions<PlanningDbContext> options)
        : base(options)
    {
    }

    public DbSet<PlanoSemanal> PlanosSemanais => Set<PlanoSemanal>();

    public DbSet<PlanoSemanalDia> PlanoSemanalDias => Set<PlanoSemanalDia>();

    public DbSet<RefeicaoPlanoSemanal> RefeicoesPlanoSemanais => Set<RefeicaoPlanoSemanal>();

    public DbSet<RefeicaoAlimento> RefeicaoAlimentos => Set<RefeicaoAlimento>();

    public DbSet<AlimentoPlanoSemanal> AlimentosPlanoSemanais => Set<AlimentoPlanoSemanal>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Carrega automaticamente todas as classes de configuração do assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlanningDbContext).Assembly);
    }
}