using FitCorePro.Training.Planning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PlanoTreinoSemanalConfiguration : IEntityTypeConfiguration<PlanoTreinoSemanal>
{
    public void Configure(EntityTypeBuilder<PlanoTreinoSemanal> builder)
    {
        builder.ToTable("TB_PLANO_TREINO_SEMANAL");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasMaxLength(36);

        builder.Property(x => x.Titulo)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Ativo)
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .IsRequired()
            .HasMaxLength(36);

        builder.HasMany(x => x.TreinosDia)
            .WithOne(x => x.PlanoTreinoSemanal)
            .HasForeignKey(x => x.PlanoTreinoSemanalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.TreinosDia)
            .HasField("_treinosDia")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}