using System.Linq.Expressions;
using MedGestor.Adapter.Driven.Database.UnitOfWork;
using MedGestor.Core.Domain.Adapters.Database.Repository;
using MedGestor.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedGestor.Adapter.Driven.Database.Repository;

public class AgendaRepository : BaseRepository, IAgendaRepository
{
    public AgendaRepository(UnitOfWorkContext context) : base(context)
    {
    }

    public async Task<bool> AdicionarAgendaAsync(Agenda agenda)
    {
        await Context.AddAsync(agenda);
        return await Commit();
    }

    public async Task<bool> AdicionarListagemAgendaAsync(IEnumerable<Agenda> agendas)
    {
        await Context.AddRangeAsync(agendas);
        return await Commit();
    }

    public async Task<Agenda?> ObterAgendaPorFiltroAsync(Expression<Func<Agenda, bool>> predicate, bool track = false)
        => await Query(predicate, track: track).FirstOrDefaultAsync();

    public async Task<IList<Agenda>> ObterListagemAgendaPorFiltroAsync(Expression<Func<Agenda, bool>> predicate,
        int? take = null, int? skip = null, bool track = false)
        => take is not null && skip is not null
            ? await Query(predicate, track: track, take: take, skip: skip,
                include: i => i.Include(m => m.Medico).ThenInclude(p => p.Pessoa))
                .ToListAsync()
            : await Query(predicate, track: track,  include: i => i.Include(m => m.Medico)
                .ThenInclude(p => p.Pessoa)).ToListAsync();

    public async Task<bool> AtualizarAgenda(Agenda agenda)
    {
        Context.Update(agenda);
        return await Commit();
    }

    public async Task<bool> RemoverAgenda(Agenda agenda)
    {
        Context.Remove(agenda);
        return await Commit();
    }
}