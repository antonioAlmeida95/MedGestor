using FluentValidation;

namespace MedGestor.Core.Domain.Entities;

public class Paciente : EntidadeBase<Paciente>
{
    public decimal Peso { get; }
    public decimal Altura { get; }

    public bool Status { get; }
    
    public Guid PessoaId { get; set; }
    public virtual Pessoa Pessoa { get; set; }

    public Paciente(decimal peso, decimal altura, bool status = false, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Peso = peso;
        Altura = altura;
        Status = status;
    }
    
    public Paciente(decimal peso, decimal altura): this(peso, altura, false){}
    
    public Paciente(){ }
    
    public override bool ValidarEntidade()
    {
        RuleFor(x => x.Peso)
            .GreaterThan(0)
            .WithMessage("O Peso é um campo obrigatório");
        
        RuleFor(x => x.Altura)
            .GreaterThan(0)
            .WithMessage("A Altura é um campo obrigatório");
        
        ValidationResult = Validate(this);
        return ValidationResult.IsValid;
    }
}