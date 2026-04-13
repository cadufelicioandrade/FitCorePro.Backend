using FitCorePro.Nutrition.Planning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Persistence.Configurations
{
    public class RefeicaoPlanoSemanalConfiguration : IEntityTypeConfiguration<RefeicaoPlanoSemanal>
    {
        public void Configure(EntityTypeBuilder<RefeicaoPlanoSemanal> builder)
        {
            builder.ToTable("TB_REFEICAO_PLANO_SEMANAL");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Tipo)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Ordem);
            builder.Property(t => t.CreatedDate)
                .HasColumnType("Datetime2");
        }
    }
}
