using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Services;

public interface IMedicoService
{
    Task<bool> IncluirMedico(Medico medico);
}