using System.Linq.Expressions;
using MedGestor.Adapter.Driven.Database.UnitOfWork;
using MedGestor.Core.Domain.Adapters.Database.Repository;
using MedGestor.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedGestor.Adapter.Driven.Database.Repository;

public class PessoaRepository : BaseRepository, IPessoaRepository
{
    public PessoaRepository(UnitOfWorkContext context) : base(context) { }

    public async Task<Pessoa?> ObterPessoaPorFiltro(Expression<Func<Pessoa, bool>> predicate, bool track = false)
        => await Query(predicate, track: track, include: i => i.Include(u => u.Usuario)
            .Include(p => p.Perfil)
            .Include(m => m.Medico)
            .Include(p => p.Paciente))
            .FirstOrDefaultAsync();
}