using System.ComponentModel.DataAnnotations;

namespace MedGestor.Adapter.Driving.Api.Dtos;

public class IncluirMedicoViewModel
{
    [Required]
    [MaxLength(10)]
    public string Crm { get; }
    
    [Required]
    [MaxLength(15)]
    public string Telefone { get; }

    [Required]
    [MaxLength(50)]
    public string Especialidade { get; }

    [Required]
    public PessoaViewModel Pessoa { get; set; }
}