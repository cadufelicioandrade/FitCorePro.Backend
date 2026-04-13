using FitCorePro.Nutrition.Tracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Persistence.Configuration
{
    public class AlimentoBaseConfiguration : IEntityTypeConfiguration<AlimentoBase>
    {
        public void Configure(EntityTypeBuilder<AlimentoBase> builder)
        {
            builder.ToTable("TB_ALIMENTO_BASE");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(355);
            builder.Property(x => x.Gramas).IsRequired();
            builder.Property(x => x.Calorias).IsRequired();
            builder.Property(x => x.Carboidratos).IsRequired();
            builder.Property(x => x.Proteinas).IsRequired();
            builder.Property(x => x.Gorduras).IsRequired();
            builder.Property(x => x.Fibras).IsRequired();
        }
    }
}
