using System.Linq.Expressions;
using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Adapters.Database.Repository;

public interface IPacienteRepository
{
    Task<bool> IncluirPacienteAsync(Paciente paciente);
    Task<bool> AtualizarPacienteAsync(Paciente paciente);
    Task<bool> RemoverPacienteAsync(Paciente paciente);
    Task<Paciente?> ObterPacientePorFiltroAsync(Expression<Func<Paciente, bool>> predicate, bool track = false);
}