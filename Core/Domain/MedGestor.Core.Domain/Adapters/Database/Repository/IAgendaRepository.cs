using System.Linq.Expressions;
using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Adapters.Database.Repository;

public interface IAgendaRepository
{
    Task<bool> AdicionarAgendaAsync(Agenda agenda);
    Task<bool> AdicionarListagemAgendaAsync(IEnumerable<Agenda> agendas);
    Task<Agenda?> ObterAgendaPorFiltroAsync(Expression<Func<Agenda, bool>> predicate, bool track = false);
    Task<IList<Agenda>> ObterListagemAgendaPorFiltroAsync(Expression<Func<Agenda, bool>> predicate,
        int? take = null, int? skip = null, bool track = false);
    Task<bool> AtualizarAgenda(Agenda agenda);
    Task<bool> RemoverAgenda(Agenda agenda);
}