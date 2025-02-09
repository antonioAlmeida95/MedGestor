using MedGestor.Adapter.Driving.Api.Dtos;

namespace MedGestor.Adapter.Driving.Api.AppService.Interfaces;

public interface IPacienteAppService
{
    Task<bool> IncluirPacienteAsync(IncluirPacienteViewModel pacienteViewModel);
}