using FitCorePro.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitCorePro.Identity.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(36);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PasswordHash)
                .IsRequired();

            builder.Property(x => x.Role)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasColumnType("datetime2");

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasMany(x => x.RefreshTokens)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}