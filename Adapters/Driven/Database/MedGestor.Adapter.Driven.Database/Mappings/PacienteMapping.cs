using MedGestor.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedGestor.Adapter.Driven.Database.Mappings;

public class PacienteMapping : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Pct_PacienteId")
            .IsRequired();
        
        builder.Property(x => x.Peso)
            .HasColumnName("Pct_Peso")
            .IsRequired();
        
        builder.Property(x => x.Altura)
            .HasColumnName("Pct_Altura")
            .IsRequired();

        builder.HasOne(s => s.Pessoa)
            .WithOne(s => s.Paciente)
            .HasForeignKey<Paciente>(s => s.PessoaId)
            .IsRequired();
        
        builder.HasMany(x => x.Consultas)
            .WithOne(x => x.Paciente)
            .HasForeignKey(x => x.PacienteId);
        
        builder.Ignore(x => x.ValidationResult);
        builder.Ignore(x => x.ClassLevelCascadeMode);
        builder.Ignore(x => x.RuleLevelCascadeMode);
        builder.Ignore(x => x.CascadeMode);
        
        builder.ToTable("Pct_Paciente", "MedHealth");
    }
}