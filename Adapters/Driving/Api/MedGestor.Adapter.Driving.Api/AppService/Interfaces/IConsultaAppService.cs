using MedGestor.Adapter.Driving.Api.Dtos;

namespace MedGestor.Adapter.Driving.Api.AppService.Interfaces;

public interface IConsultaAppService
{
    Task<bool> IncluirConsultaAsync(Guid agendaId);
    Task<bool> AceitarRecusarConsultaAsync(Guid consultaId, bool aceite);
    Task<bool> CancelarConsultaAsync(CancelarConsultaViewModel cancelarConsultaViewModel);
    Task<IEnumerable<ConsultaViewModel>> ObterConsultasPorFiltrosAsync(Guid? medicoId = null, Guid? pacienteId = null);
}