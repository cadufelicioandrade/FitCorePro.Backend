using FitCorePro.Training.Planning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TreinoDiaConfiguration : IEntityTypeConfiguration<TreinoDia>
{
    public void Configure(EntityTypeBuilder<TreinoDia> builder)
    {
        builder.ToTable("TB_TREINO_DIA");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasMaxLength(36);

        builder.Property(x => x.DiaSemana)
            .IsRequired();

        builder.Property(x => x.PlanoTreinoSemanalId)
            .IsRequired()
            .HasMaxLength(36);

        builder.HasOne(x => x.PlanoTreinoSemanal)
            .WithMany(x => x.TreinosDia)
            .HasForeignKey(x => x.PlanoTreinoSemanalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Exercicios)
            .WithOne(x => x.TreinoDia)
            .HasForeignKey(x => x.TreinoDiaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Exercicios)
            .HasField("_exercicios")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}