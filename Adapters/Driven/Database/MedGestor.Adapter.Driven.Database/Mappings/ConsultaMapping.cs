using MedGestor.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedGestor.Adapter.Driven.Database.Mappings;

public class ConsultaMapping : IEntityTypeConfiguration<Consulta>
{
    public void Configure(EntityTypeBuilder<Consulta> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Cst_ConsultaId")
            .IsRequired();
        
        builder.Property(x => x.Aceito)
            .HasColumnName("Cst_Aceito")
            .HasDefaultValue(false);
        
        builder.Property(x => x.Cancelada)
            .HasColumnName("Cst_Cancelada")
            .HasDefaultValue(false);
        
        builder.Property(x => x.Justificativa)
            .HasColumnName("Cst_Justificativa");
        
        builder.Property(x => x.AgendaId)
            .HasColumnName("Agd_AgendaId")
            .IsRequired();
        
        builder.Property(x => x.PacienteId)
            .HasColumnName("Pct_PacienteId")
            .IsRequired();
        
        builder.Ignore(x => x.ValidationResult);
        builder.Ignore(x => x.ClassLevelCascadeMode);
        builder.Ignore(x => x.RuleLevelCascadeMode);
        builder.Ignore(x => x.CascadeMode);
        
        builder.ToTable("Cst_Consulta", "MedHealth");
    }
}