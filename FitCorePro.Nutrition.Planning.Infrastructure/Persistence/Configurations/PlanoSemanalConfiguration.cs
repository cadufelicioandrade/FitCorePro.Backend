using FitCorePro.Nutrition.Planning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Persistence.Configurations;

public sealed class PlanoSemanalConfiguration : IEntityTypeConfiguration<PlanoSemanal>
{
    public void Configure(EntityTypeBuilder<PlanoSemanal> builder)
    {
        builder.ToTable("PlanoSemanal");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany(p => p.PlanoSemanalDias)
            .WithOne()
            .HasForeignKey(d => d.PlanoSemanalId);
    }
}