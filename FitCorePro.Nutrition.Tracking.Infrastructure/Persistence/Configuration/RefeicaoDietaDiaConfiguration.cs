using FitCorePro.Nutrition.Tracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Persistence.Configuration
{
    public class RefeicaoDietaDiaConfiguration : IEntityTypeConfiguration<RefeicaoDietaDia>
    {
        public void Configure(EntityTypeBuilder<RefeicaoDietaDia> builder)
        {
            builder.ToTable("TB_REFEICAO_DIETA_DIA");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasMaxLength(36);

            builder.Property(r => r.Titulo)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(r => r.Ordem)
                .IsRequired();

            builder.Property(r => r.DietaDiaId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(r => r.CreatedDate)
                .HasColumnType("datetime2");

            builder.HasOne(r => r.DietaDia)
                .WithMany(d => d.RefeicoesDietaDia)
                .HasForeignKey(r => r.DietaDiaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.AlimentosDietaDia)
                .WithOne(a => a.RefeicaoDietaDia)
                .HasForeignKey(a => a.RefeicaoDietaDiaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}