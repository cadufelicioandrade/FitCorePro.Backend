using FitCorePro.Training.Planning.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Training.Planning.Infrastructure.Persistence
{
    public class TraniningDbContext : DbContext
    {
        public TraniningDbContext(DbContextOptions<TraniningDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlanoTreinoSemanal> PlanoTreinoSemanal { get; set; }
        public DbSet<TreinoDia> TreinoDia { get; set; }
        public DbSet<Exercicio> Exercicio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TraniningDbContext).Assembly);
        }
    }
}