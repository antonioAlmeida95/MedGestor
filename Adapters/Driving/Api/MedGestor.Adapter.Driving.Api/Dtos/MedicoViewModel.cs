namespace MedGestor.Adapter.Driving.Api.Dtos;

public class MedicoViewModel
{
    public Guid MedicoId { get; set; }
    public string Nome { get; set; }
    public string Especialidade { get; set; }
    public string Crm { get; set; }

    public IEnumerable<AgendaSimplificada> Agendas { get; set; }
}

public class AgendaSimplificada
{
    public Guid AgendaId { get; set; }
    public DateTimeOffset? DataInicio { get; set; }
    public DateTimeOffset? DataFim { get; set; }
    public decimal Valor { get; set; }
}