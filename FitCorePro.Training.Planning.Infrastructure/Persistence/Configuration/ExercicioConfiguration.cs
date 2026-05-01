using FitCorePro.Training.Planning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ExercicioConfiguration : IEntityTypeConfiguration<Exercicio>
{
    public void Configure(EntityTypeBuilder<Exercicio> builder)
    {
        builder.ToTable("TB_EXERCICIO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasMaxLength(36);

        builder.Property(x => x.TipoExercicio)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Serie)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Carga)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.TreinoDiaId)
            .IsRequired()
            .HasMaxLength(36);

        builder.HasOne(x => x.TreinoDia)
            .WithMany(x => x.Exercicios)
            .HasForeignKey(x => x.TreinoDiaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}