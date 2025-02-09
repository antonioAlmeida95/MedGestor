using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Services;

public interface IConsultaService
{
    Task<bool> IncluirConsultaAsync(Consulta consulta);
    Task<bool> CancelarConsultaAsync(Guid consultaId, string? justificativa);
    Task<bool> AceiteRecusaConsulta(Guid consultaId, bool aceite);
    Task<IEnumerable<Consulta>> ObterConsultasPorFiltroAsync(Guid? medicoId = null, Guid? pacienteId = null);
}