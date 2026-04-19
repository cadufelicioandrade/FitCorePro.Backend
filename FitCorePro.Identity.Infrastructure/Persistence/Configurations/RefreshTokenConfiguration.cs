using FitCorePro.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Identity.Infrastructure.Persistence.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("TB_REFRESH_TOKEN");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(36);

            builder.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.UsuarioId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(x => x.ExpiresAt)
                .HasColumnType("timestamp with time zone");

            builder.Property(x => x.CreatedDate)
                .HasColumnType("timestamp with time zone");

            builder.Property(x => x.Revogado)
                .IsRequired();

            builder.HasIndex(x => x.Token)
                .IsUnique();
        }
    }
}