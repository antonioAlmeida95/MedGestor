using System.Linq.Expressions;
using MedGestor.Adapter.Driven.Database.UnitOfWork;
using MedGestor.Core.Domain.Adapters.Database.Repository;
using MedGestor.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedGestor.Adapter.Driven.Database.Repository;

public class PerfilRepository : BaseRepository, IPerfilRepository
{
    public PerfilRepository(UnitOfWorkContext context) : base(context) { }

    public async Task<Perfil?> ObterPerfilPorFiltro(Expression<Func<Perfil, bool>> predicate, bool track = false)
        => await Query(predicate, track: track, include: p => p.Include(x => x.Permissoes)
            .ThenInclude(s => s.Permissao)).FirstOrDefaultAsync();

}