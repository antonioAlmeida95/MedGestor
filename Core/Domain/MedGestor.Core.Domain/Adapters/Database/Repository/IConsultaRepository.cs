using System.Linq.Expressions;
using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Adapters.Database.Repository;

public interface IConsultaRepository
{
    Task<bool> IncluirConsultaAsync(Consulta consulta);
    Task<bool> AtualizarConsulta(Consulta consulta);
    Task<IEnumerable<Consulta>> ObterConsultasPorFiltro(Expression<Func<Consulta, bool>> predicate, bool track = false);
}