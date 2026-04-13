using FitCorePro.Nutrition.Tracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Persistence.Configuration
{
    public class AlimentoDietaDiaConfiguration : IEntityTypeConfiguration<AlimentoDietaDia>
    {
        public void Configure(EntityTypeBuilder<AlimentoDietaDia> builder)
        {
            builder.ToTable("TB_ALIMENTO_DIETA_DIA");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Nome).IsRequired().HasMaxLength(355);
            builder.Property(d => d.QuantidadeGramas).IsRequired();
            builder.Property(d => d.Calorias).IsRequired();
            builder.Property(d => d.Carboidratos).IsRequired();
            builder.Property(d => d.Proteinas).IsRequired();
            builder.Property(d => d.Gorduras).IsRequired();
            builder.Property(d => d.Fibras).IsRequired();
            builder.Property(d => d.CreatedDate).HasColumnType("datetime2");
        }
    }
}
