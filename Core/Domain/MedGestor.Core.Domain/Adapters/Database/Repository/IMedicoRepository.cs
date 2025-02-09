using System.Linq.Expressions;
using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Adapters.Database.Repository;

public interface IMedicoRepository
{
    Task<bool> IncluirMedicoAsync(Medico medico);
    Task<Medico?> ObterMedicoPorFiltroAsync(Expression<Func<Medico, bool>> predicate, bool track = false);
    
    Task<IEnumerable<Medico>> ObterMedicosPorFiltroAsync(Expression<Func<Medico, bool>> predicate,
        int? skip = null, int? take = null, bool track = false);
}