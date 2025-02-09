using MedGestor.Core.Domain.Entities;

namespace MedGestor.Core.Domain.Services;

public interface IPacienteService
{
    Task<bool> IncluirPacienteAsync(Paciente paciente);
}