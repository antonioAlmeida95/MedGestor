using MedGestor.Adapter.Driving.Api.Dtos;

namespace MedGestor.Adapter.Driving.Api.AppService.Interfaces;

public interface IMedicoAppService
{
    Task<bool> IncluirMedicoAsync(IncluirMedicoViewModel medicoViewModel);
}