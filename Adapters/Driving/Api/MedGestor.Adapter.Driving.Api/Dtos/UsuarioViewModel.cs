using System.ComponentModel.DataAnnotations;

namespace MedGestor.Adapter.Driving.Api.Dtos;

public class UsuarioViewModel
{
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Senha { get; set; }

    public bool Status { get; set;  }
}