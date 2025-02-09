using System.ComponentModel.DataAnnotations;
using MedGestor.Adapter.Driving.Api.Dtos.Enums;

namespace MedGestor.Adapter.Driving.Api.Dtos;

public class PessoaViewModel
{
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public string Documento { get; set; }
    
    [Required]
    public DateTimeOffset DataNascimento { get; set; }
    
    [Required]
    public Genero Genero { get; }
    
    [Required]
    public UsuarioViewModel Usuario { get; set; }
}