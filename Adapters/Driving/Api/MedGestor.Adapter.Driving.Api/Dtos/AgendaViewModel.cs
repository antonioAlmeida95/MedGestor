namespace MedGestor.Adapter.Driving.Api.Dtos;

public class AgendaViewModel
{
    public Guid AgendaId { get; set; }
    public Guid MedicoId { get; set; }
    public string Nome { get; set; }
    public string Especialidade { get; set; }
    public int Duracao { get; set; }

    public DateTimeOffset? DataInicio { get; set; }

    public DateTimeOffset? DataFim { get; set; }
    public decimal Valor { get; set; }
}