using System.ComponentModel.DataAnnotations;

namespace MedGestor.Adapter.Driving.Api.Dtos;

public class CancelarConsultaViewModel
{
    [Required]
    public Guid ConsultaId { get; set; }
    
    [Required]
    public string Justificativa { get; set; }
}