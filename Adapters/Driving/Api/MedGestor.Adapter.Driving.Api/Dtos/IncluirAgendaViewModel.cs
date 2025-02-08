using System.ComponentModel.DataAnnotations;

namespace MedGestor.Adapter.Driving.Api.Dtos;

public class IncluirAgendaViewModel
{
    [Required]
    public Guid MedicoId { get; set; }

    [Required]
    public int Duracao { get; set; }

    public DateTimeOffset? DataInicio { get; set; }

    public DateTimeOffset? DataFim { get; set; }

    [Required]
    public decimal Valor { get; set; }
}