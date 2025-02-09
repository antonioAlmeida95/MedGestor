using System.Linq.Expressions;
using MedGestor.Adapter.Driven.Database.UnitOfWork;
using MedGestor.Core.Domain.Adapters.Database.Repository;
using MedGestor.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedGestor.Adapter.Driven.Database.Repository;

public class PacienteRepository : BaseRepository, IPacienteRepository
{
    public PacienteRepository(UnitOfWorkContext context) : base(context) { }

    public async Task<bool> IncluirPacienteAsync(Paciente paciente)
    {
        await Context.AddAsync(paciente);
        return await Commit();
    }

    public async Task<Paciente?> ObterPacientePorFiltroAsync(Expression<Func<Paciente, bool>> predicate,
        bool track = false) => await Query(predicate, track: track).FirstOrDefaultAsync();
}