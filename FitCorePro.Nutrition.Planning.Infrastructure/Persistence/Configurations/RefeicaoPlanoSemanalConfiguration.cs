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

            builder.Property(t => t.Id)
                .HasMaxLength(36);

            builder.Property(t => t.Tipo)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Ordem)
                .IsRequired();

            builder.Property(t => t.CreatedDate)
                .HasColumnType("datetime2");

            builder.Property(t => t.PlanoSemanalDiaId)
                .IsRequired()
                .HasMaxLength(36);

            builder.HasOne(t => t.PlanoSemanalDia)
                .WithMany(d => d.RefeicoesPlanoSemanal)
                .HasForeignKey(t => t.PlanoSemanalDiaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.AlimentosPlanoSemanais)
                .WithOne(a => a.RefeicaoPlanoSemanal)
                .HasForeignKey(a => a.RefeicaoPlanoSemanalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}