using FluentValidation;

namespace MedGestor.Core.Domain.Entities;

public class Consulta : EntidadeBase<Consulta>
{
    public bool Aceito { get; private set; }
    public bool Cancelada { get; private set; }
    public string? Justificativa { get; private set; }

    public Guid AgendaId { get;  private set; }
    public virtual Agenda Agenda { get; set; }

    public Guid PacienteId { get; private set; }
    public virtual Paciente Paciente { get; set; }

    public void AlterarCancelamento(bool cancelada) => Cancelada = cancelada;
    public void AlterarAceite(bool aceito) => Aceito = aceito;
    public void AlterarJustificativa(string justificativa) => Justificativa = justificativa;
    public void AlterarPacienteId(Guid pacienteId) => PacienteId = pacienteId;

    public Consulta(){}
    
    public Consulta(Guid agendaId, Guid pacienteId) : this(agendaId, pacienteId, null){}
    
    public Consulta(Guid agendaId, Guid pacienteId, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        AgendaId = agendaId;
        PacienteId = pacienteId;
    }

    public override bool ValidarEntidade()
    {
        RuleFor(x => x.Justificativa)
            .Must(c => string.IsNullOrEmpty(c) && Cancelada)
            .WithMessage("O Nome é um campo obrigatório");
        
        ValidationResult = Validate(this);
        return ValidationResult.IsValid;
    }
}