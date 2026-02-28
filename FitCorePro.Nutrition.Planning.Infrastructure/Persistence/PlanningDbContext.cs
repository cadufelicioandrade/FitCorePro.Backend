using FitCorePro.Nutrition.Planning.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Persistence;

public sealed class PlanningDbContext //: DbContext
{
    //public PlanningDbContext(DbContextOptions<PlanningDbContext> options)
    //    : base(options)
    //{
    //}

    //public DbSet<PlanoSemanal> PlanoSemanais { get; set; }
    //public DbSet<PlanoSemanalDia> PlanoSemanalDias { get; set; }
    //public DbSet<RefeicaoPlanoSemanal> RefeicoesPlanoSemanal { get; set; }
    //public DbSet<AlimentoPlanoSemanal> AlimentosPlanoSemanal { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    ConfigurePlanoSemanal(modelBuilder);
    //    ConfigurePlanoSemanalDia(modelBuilder);
    //    ConfigureRefeicaoPlanoSemanal(modelBuilder);
    //    ConfigureAlimentoPlanoSemanal(modelBuilder);
    //}

    //private static void ConfigurePlanoSemanal(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<PlanoSemanal>(entity =>
    //    {
    //        entity.HasKey(p => p.Id);

    //        entity.Property(p => p.Id)
    //              .IsRequired();

    //        entity.Property(p => p.Nome)
    //              .IsRequired()
    //              .HasMaxLength(150);

    //        entity.Property(p => p.IdUsuario)
    //              .IsRequired();

    //        entity.Property(p => p.Ativo)
    //              .IsRequired();

    //        entity.Property(p => p.CreatedDate)
    //              .IsRequired();

    //        entity.HasMany(p => p.PlanoSemanalDias)
    //              .WithOne(d => d.PlanoSemanal)
    //              .HasForeignKey(d => d.PlanoSemanaId)
    //              .OnDelete(DeleteBehavior.Cascade);
    //    });
    //}

    //private static void ConfigurePlanoSemanalDia(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<PlanoSemanalDia>(entity =>
    //    {
    //        entity.HasKey(d => d.Id);

    //        entity.Property(d => d.DiaSemana)
    //              .IsRequired();

    //        entity.Property(d => d.CreatedDate)
    //              .IsRequired();

    //        entity.HasMany(d => d.Refeicoes)
    //              .WithOne(r => r.PlanoSemanalDia)
    //              .HasForeignKey(r => r.PlanoSemanaDiaId)
    //              .OnDelete(DeleteBehavior.Cascade);
    //    });
    //}

    //private static void ConfigureRefeicaoPlanoSemanal(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<RefeicaoPlanoSemanal>(entity =>
    //    {
    //        entity.HasKey(r => r.Id);

    //        entity.Property(r => r.Tipo)
    //              .IsRequired()
    //              .HasMaxLength(100);

    //        entity.Property(r => r.Origem)
    //              .IsRequired();

    //        entity.Property(r => r.CreatedDate)
    //              .IsRequired();

    //        entity.HasMany(r => r.Alimentos)
    //              .WithOne(a => a.RefeicaoPlanoSemanal)
    //              .HasForeignKey(a => a.RefeicaoId)
    //              .OnDelete(DeleteBehavior.Cascade);
    //    });
    //}

    //private static void ConfigureAlimentoPlanoSemanal(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<AlimentoPlanoSemanal>(entity =>
    //    {
    //        entity.HasKey(a => a.Id);

    //        entity.Property(a => a.Nome)
    //              .IsRequired()
    //              .HasMaxLength(150);

    //        entity.Property(a => a.Gramas)
    //              .IsRequired();

    //        entity.Property(a => a.CreatedDate)
    //              .IsRequired();
    //    });
    //}
}