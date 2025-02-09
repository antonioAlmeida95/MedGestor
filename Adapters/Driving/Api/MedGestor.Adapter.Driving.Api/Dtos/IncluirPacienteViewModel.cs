using System.ComponentModel.DataAnnotations;

namespace MedGestor.Adapter.Driving.Api.Dtos;

public class IncluirPacienteViewModel
{
    [Required]
    public decimal Peso { get; set; }

    [Required]
    public decimal Altura { get; set; }
    
    [Required]
    public PessoaViewModel Pessoa { get; set; }
}