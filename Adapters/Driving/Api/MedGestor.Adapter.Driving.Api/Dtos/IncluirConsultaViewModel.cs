using System.ComponentModel.DataAnnotations;

namespace MedGestor.Adapter.Driving.Api.Dtos;

public class IncluirConsultaViewModel
{
    [Required]
    public Guid AgendaId { get; set; }
}