using System.Linq.Expressions;
using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Adapters.Database.Repository;

public interface IPessoaRepository
{
    Task<Pessoa?> ObterPessoaPorFiltro(Expression<Func<Pessoa, bool>> predicate, bool track = false);
}