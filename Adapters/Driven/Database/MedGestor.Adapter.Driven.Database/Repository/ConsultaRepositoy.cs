using System.Linq.Expressions;
using MedGestor.Adapter.Driven.Database.UnitOfWork;
using MedGestor.Core.Domain.Adapters.Database.Repository;
using MedGestor.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedGestor.Adapter.Driven.Database.Repository;

public class ConsultaRepositoy : BaseRepository, IConsultaRepository
{
    public ConsultaRepositoy(UnitOfWorkContext context)
        : base(context) { }

    public async Task<bool> IncluirConsultaAsync(Consulta consulta)
    {
        await Context.Consulta.AddAsync(consulta);
        return await Commit();
    }

    public async Task<bool> AtualizarConsulta(Consulta consulta)
    {
        Context.Consulta.Update(consulta);
        return await Commit();
    }

    public async Task<IEnumerable<Consulta>> ObterConsultasPorFiltro(Expression<Func<Consulta, bool>> predicate,
        bool track = false) => await Query(predicate, track: track, include: i =>
        i.Include(c => c.Agenda)
            .ThenInclude(c => c.Medico)
            .ThenInclude(c => c.Pessoa)
            .Include(p => p.Paciente)
            .ThenInclude(x => x.Pessoa)).ToListAsync();
}