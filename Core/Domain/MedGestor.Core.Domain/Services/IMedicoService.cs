using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Services;

public interface IMedicoService
{
    Task<bool> IncluirMedico(Medico medico);

    Task<IEnumerable<Medico>> ObterMedicosPorFiltroAsync(string? especialidade, string? nome, string? crm);
}