using MedGestor.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedGestor.Adapter.Driven.Database.Mappings;

public class AgendaMapping : IEntityTypeConfiguration<Agenda>
{
    public void Configure(EntityTypeBuilder<Agenda> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Agd_AgendaId")
            .IsRequired();

        builder.Property(x => x.DataInicio)
            .HasColumnName("Agd_DataInicio")
            .IsRequired();
        
        builder.Property(x => x.DataFim)
            .HasColumnName("Agd_DataFim")
            .IsRequired();
        
        builder.Property(x => x.Duracao)
            .HasColumnName("Agd_Duracao")
            .IsRequired();
        
        builder.Property(x => x.Dia)
            .HasColumnName("Agd_Dia")
            .IsRequired();
        
        builder.Property(x => x.Valor)
            .HasColumnName("Agd_Valor")
            .IsRequired();
        
        builder.Ignore(x => x.ValidationResult);
        builder.Ignore(x => x.ClassLevelCascadeMode);
        builder.Ignore(x => x.RuleLevelCascadeMode);
        builder.Ignore(x => x.CascadeMode);
        
        builder.ToTable("Agd_Agenda", "MedHealth");
    }
}