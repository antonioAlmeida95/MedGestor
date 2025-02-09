using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace MedGestor.Core.Domain.Entities;

public class Medico : EntidadeBase<Medico>
{
    [Required]
    [MaxLength(10)]
    public string Crm { get; private set;  }
    
    [Required]
    [MaxLength(15)]
    public string Telefone { get; private set;}

    [Required]
    [MaxLength(50)]
    public string Especialidade { get; private set; }

    public bool Status { get; private set; }
    
    public Guid PessoaId { get; private set; }
    public virtual Pessoa Pessoa { get; set; }

    public ICollection<Agenda> Agendas { get; set; } = [];
    
    public Medico(string crm, string telefone, string especialidade) 
        : this(crm, telefone, especialidade, null){ }

    public Medico(string crm, string telefone, string especialidade, bool? status = null, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Crm = crm;
        Telefone = telefone;
        Especialidade = especialidade;
        Status = status ?? false;
    }
    
    public Medico() { }
    
    public override bool ValidarEntidade()
    {
        RuleFor(x => x.Crm)
            .NotEmpty()
            .WithMessage("O Crm é um campo obrigatório");
        
        RuleFor(x => x.Telefone)
            .NotEmpty()
            .WithMessage("O Telefone é um campo obrigatório");
        
        ValidationResult = Validate(this);
        return ValidationResult.IsValid;
    }
}