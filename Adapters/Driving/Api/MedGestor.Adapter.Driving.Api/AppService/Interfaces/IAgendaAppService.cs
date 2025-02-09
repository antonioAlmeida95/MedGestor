using MedGestor.Adapter.Driving.Api.Dtos;

namespace MedGestor.Adapter.Driving.Api.AppService.Interfaces;

public interface IAgendaAppService
{
    Task<bool> IncluirAgendas(IEnumerable<IncluirAgendaViewModel> agendas);

    Task<bool> AtualizarAgenda(AtualizarAgendaViewModel agenda);

    Task<bool> RemoverAgendaPorId(Guid agendaId);

    Task<IEnumerable<AgendaViewModel>> ObterAgendasPorMedicoId(Guid medicoId,
        int? take = null, int? skip = null);
    Task<AgendaViewModel?> ObterAgendaPorId(Guid agendaId);
}