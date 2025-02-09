using System.Linq.Expressions;
using MedGestor.Adapter.Driven.Database.UnitOfWork;
using MedGestor.Core.Domain.Adapters.Database.Repository;
using MedGestor.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedGestor.Adapter.Driven.Database.Repository;

public class MedicoRepository : BaseRepository, IMedicoRepository
{
    public MedicoRepository(UnitOfWorkContext context) : base(context) { }

    public async Task<bool> IncluirMedicoAsync(Medico medico)
    {
        await Context.AddAsync(medico);
        return await Commit();
    }
    public async Task<Medico?> ObterMedicoPorFiltroAsync(Expression<Func<Medico, bool>> predicate, bool track = false)
        => await Query(predicate, track: track).FirstOrDefaultAsync();

    public async Task<IEnumerable<Medico>> ObterMedicosPorFiltroAsync(Expression<Func<Medico, bool>> predicate,
        int? skip = null, int? take = null, bool track = false)
        => skip is not null && take is not null
            ? await Query(predicate, take: take, skip: skip, track: track, include: i => i.Include(p => p.Agendas)
                    .Include(p => p.Pessoa)).ToListAsync()
            : await Query(predicate, track: track, include: i => i.Include(p => p.Agendas)
                .Include(p => p.Pessoa)).ToListAsync();

}