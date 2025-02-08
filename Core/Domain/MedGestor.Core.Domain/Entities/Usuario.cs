using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace MedGestor.Core.Domain.Entities;

public class Usuario : EntidadeBase<Usuario>
{
    [MaxLength(100)]
    public string Email { get; }

    [MaxLength(100)]
    public string Senha { get; private set; }

    public bool Status { get; private set;  }
    
    public virtual Pessoa Pessoa { get; set; }

    public Usuario(string email, string senha, bool status = false, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Email = email;
        Senha = senha;
        Status = status;
    }

    public void AlterarSenha(string senha) => Senha = senha;

    public Usuario(string email, string senha) : this(email, senha, false) { }

    public Usuario() { }

    public override bool ValidarEntidade()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O Email é um campo obrigatório");
        
        RuleFor(x => x.Senha)
            .NotEmpty()
            .WithMessage("O Email é um campo obrigatório");
        
        ValidationResult = Validate(this);
        return ValidationResult.IsValid;
    }
}