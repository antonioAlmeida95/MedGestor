using FluentValidation;
using MedGestor.Core.Domain.Entities.Enums;

namespace MedGestor.Core.Domain.Entities;

public class Pessoa : EntidadeBase<Pessoa>
{
    public string Nome { get; private set;}
    public string Documento { get; private set;}
    public DateTimeOffset DataNascimento { get; private set;}
    public Genero Genero { get; private set;}

    public Guid PerfilId { get; private set; }
    public virtual Perfil Perfil { get; set; }

    public Guid UsuarioId { get; private set; }
    public virtual Usuario Usuario { get; set; }

    public virtual Medico Medico { get; set; }
    public virtual Paciente Paciente { get; set; }

    public void AlterarPerfilId(Guid perfilId) => PerfilId = perfilId;

    public Pessoa(string nome, string documento, DateTimeOffset dataNascimento, Genero genero, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Nome = nome;
        Documento = documento;
        DataNascimento = dataNascimento;
        Genero = genero;
    }

    public Pessoa(string nome, string documento, DateTimeOffset dataNascimento, Genero genero)
        : this(nome, documento, dataNascimento, genero, null) { }

    public Pessoa() { }

    public override bool ValidarEntidade()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O Nome é um campo obrigatório");
        
        RuleFor(x => x.Documento)
            .NotEmpty()
            .WithMessage("O Documento é um campo obrigatório");
        
        ValidationResult = Validate(this);
        return ValidationResult.IsValid;
    }
}