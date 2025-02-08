using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MedGestor.Core.Domain.Entities.Enums;

namespace MedGestor.Core.Domain.Entities;

public class Agenda : EntidadeBase<Agenda>
{
    [Required]
    public DateTimeOffset DataInicio { get; }

    public DateTimeOffset DataFim { get; }
    
    [Required]
    public int Duracao { get; }
    
    [Required]
    public Dia Dia { get; }

    public decimal Valor { get; }

    [Required]
    public Guid MedicoId { get; private set; }
    public virtual Medico Medico { get; set; }

    public void AlterarMedicoId(Guid medicoId) => MedicoId = medicoId;

    public Agenda(Guid medicoId, DateTimeOffset dataInicio, DateTimeOffset dataFim, int duracao,
        Dia dia, decimal valor) 
        : this(medicoId, dataInicio, dataFim, duracao, dia, valor, null) { }

    public Agenda(Guid medicoId, DateTimeOffset dataInicio, DateTimeOffset dataFim,
        int duracao, Dia dia, decimal valor, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        MedicoId = medicoId;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Duracao = duracao;
        Dia = dia;
        Valor = valor;
    }
    
    public Agenda(){ }
    
    public override bool ValidarEntidade()
    {
        RuleFor(x => x.Duracao)
            .GreaterThan(0)
            .WithMessage("A Duracao é um campo obrigatório");
        
        ValidationResult = Validate(this);
        return ValidationResult.IsValid;
    }
}