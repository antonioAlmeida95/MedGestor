using FluentValidation;

namespace MedGestor.Core.Domain.Entities;

public class Paciente : EntidadeBase<Paciente>
{
    public decimal Peso { get; private set;}
    public decimal Altura { get; private set;}
    
    public Guid PessoaId { get; private set;}
    public virtual Pessoa Pessoa { get; set; }
    
    public ICollection<Consulta> Consultas { get; set; } = [];

    public Paciente(decimal peso, decimal altura, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Peso = peso;
        Altura = altura;
    }
    
    public Paciente(decimal peso, decimal altura): this(peso, altura, null){}
    
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