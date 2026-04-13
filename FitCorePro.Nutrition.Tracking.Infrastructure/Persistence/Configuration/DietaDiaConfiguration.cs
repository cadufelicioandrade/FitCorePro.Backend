using FitCorePro.Nutrition.Tracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Persistence.Configuration
{
    public class DietaDiaConfiguration : IEntityTypeConfiguration<DietaDia>
    {
        public void Configure(EntityTypeBuilder<DietaDia> builder)
        {
            builder.ToTable("TB_DIETA_DIA");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.UsuarioId).IsRequired().HasMaxLength(255);
            builder.Property(d => d.DataDieta).IsRequired().HasColumnType("datetime2");

            builder.HasMany(d => d.RefeicoesDietaDia)
                .WithOne(r => r.DietaDia)
                .HasForeignKey(r => r.DietaDiaId);
        }
    }
}
