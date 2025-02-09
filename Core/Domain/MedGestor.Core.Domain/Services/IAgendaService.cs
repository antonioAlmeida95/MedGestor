using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Services;

public interface IAgendaService
{
    Task<bool> IncluirAgendas(IEnumerable<Agenda> agendas);

    Task<bool> AtualizarAgenda(Agenda agenda);

    Task<bool> RemoverAgendaPorId(Guid agendaId);

    Task<IEnumerable<Agenda>> ObterAgendasPorMedicoId(Guid medicoId,
        int? take = null, int? skip = null);
    Task<Agenda?> ObterAgendaPorId(Guid agendaId);
}