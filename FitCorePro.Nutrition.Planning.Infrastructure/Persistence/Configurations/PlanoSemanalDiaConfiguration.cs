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
            builder.HasKey(a => a.Id);
            builder.Property(p => p.Id).HasMaxLength(36);
            builder.Property(p => p.PlanoSemanalId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.DiaSemana).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("timestamp with time zone");

            builder.HasMany(p => p.RefeicoesPlanoSemanal)
                    .WithOne(p => p.PlanoSemanalDia)
                    .HasForeignKey(r => r.PlanoSemanalDiaId);

            builder.HasOne(p => p.PlanoSemanal)
                .WithMany(p => p.PlanoSemanalDias)
                .HasForeignKey(p => p.PlanoSemanalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
