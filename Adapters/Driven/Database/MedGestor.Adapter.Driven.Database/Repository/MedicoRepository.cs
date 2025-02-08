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

    public async Task<bool> AtualizaMedicoAsync(Medico medico)
    {
        Context.Update(medico);
        return await Commit();
    }

    public async Task<bool> RemoverMedicoAsync(Medico medico)
    {
        Context.Remove(medico);
        return await Commit();
    }

    public async Task<Medico?> ObterMedicoPorFiltroAsync(Expression<Func<Medico, bool>> predicate, bool track = false)
        => await Query(predicate, track: track).FirstOrDefaultAsync();
}