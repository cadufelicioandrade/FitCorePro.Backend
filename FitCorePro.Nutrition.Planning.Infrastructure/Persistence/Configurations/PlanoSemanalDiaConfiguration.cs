using FitCorePro.Nutrition.Planning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Persistence.Configurations
{
    public class PlanoSemanalDiaConfiguration : IEntityTypeConfiguration<PlanoSemanalDia>
    {
        public void Configure(EntityTypeBuilder<PlanoSemanalDia> builder)
        {
            builder.ToTable("TB_PLANO_SEMANAL_DIA");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.DiaSemana).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("Datetime2");

            builder.HasMany(p => p.RefeicoesPlanoSemanal)
                .WithOne(p => p.PlanoSemanalDia)
                .HasForeignKey(r => r.PlanoSemanalDiaId);
        }
    }
}
