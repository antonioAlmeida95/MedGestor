using MedGestor.Adapter.Driving.Api.Dtos.Enums;

namespace MedGestor.Adapter.Driving.Api.Dtos;

public class ConsultaViewModel
{
    public Guid ConsultaId { get; set; }
    public bool Aceito { get; set; }
    public bool Cancelada { get; set; }
    public PacienteSimplificadoViewModel Paciente { get; set; }
    public AgendaViewModel Agenda { get; set; }
}

public class PacienteSimplificadoViewModel
{
    public string Nome { get; set; }
    public decimal Peso { get; set; }
    public decimal Altura { get; set; }
    public DateTimeOffset DataNascimento { get; set; }
    public Genero Genero { get; set; }
}