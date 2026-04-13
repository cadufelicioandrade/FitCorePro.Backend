using FitCorePro.Nutrition.Planning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Persistence.Configurations;

public sealed class PlanoSemanalConfiguration : IEntityTypeConfiguration<PlanoSemanal>
{
    public void Configure(EntityTypeBuilder<PlanoSemanal> builder)
    {
        builder.ToTable("TB_PLANO_SEMANAL");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(355);
        builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(255);
        builder.Property(p => p.CreatedDate).HasColumnType("Datetime2");

        builder.HasMany(p => p.PlanoSemanalDias)
            .WithOne(d => d.PlanoSemanal)
            .HasForeignKey(d => d.PlanoSemanalId);
    }
}