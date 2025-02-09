using System.Linq.Expressions;
using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Adapters.Database.Repository;

public interface IPerfilRepository
{
    Task<Perfil?> ObterPerfilPorFiltro(Expression<Func<Perfil, bool>> predicate, bool track = false);
}