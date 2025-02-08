using System.Linq.Expressions;
using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Adapters.Database.Repository;

public interface IMedicoRepository
{
    Task<bool> IncluirMedicoAsync(Medico medico);
    Task<bool> AtualizaMedicoAsync(Medico medico);
    Task<bool> RemoverMedicoAsync(Medico medico);
    Task<Medico?> ObterMedicoPorFiltroAsync(Expression<Func<Medico, bool>> predicate, bool track = false);
}