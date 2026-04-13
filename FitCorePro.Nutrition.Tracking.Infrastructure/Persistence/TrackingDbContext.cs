using FitCorePro.Nutrition.Tracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Persistence
{
    public class TrackingDbContext : DbContext
    {
        public TrackingDbContext(DbContextOptions<TrackingDbContext> options) : base(options) { }

        public DbSet<AlimentoBase> AlimentoBase { get; set; }

        public DbSet<AlimentoDietaDia> AlimentoDietaDia { get; set; }
        public DbSet<DietaDia> DietaDia { get; set; }
        public DbSet<RefeicaoDietaDia> RefeicaoDietaDia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrackingDbContext).Assembly);
        }
    }
}
