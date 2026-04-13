using FitCorePro.Nutrition.Planning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Persistence.Configurations
{
    public class AlimentoPlanoSemanalConfiguration : IEntityTypeConfiguration<AlimentoPlanoSemanal>
    {
        public void Configure(EntityTypeBuilder<AlimentoPlanoSemanal> builder)
        {
            builder.ToTable("TB_ALIMENTO_PLANO_SEMANAL");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nome).IsRequired().HasMaxLength(255);
            builder.Property(a => a.Gramas).IsRequired();
            builder.Property(a => a.CreatedDate).HasColumnType("datetime2");
        }
    }
}
