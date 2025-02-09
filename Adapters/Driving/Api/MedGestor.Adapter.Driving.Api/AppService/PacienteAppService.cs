using AutoMapper;
using MedGestor.Adapter.Driving.Api.AppService.Interfaces;
using MedGestor.Adapter.Driving.Api.Dtos;
using MedGestor.Core.Domain.Entities;
using MedGestor.Core.Domain.Services;

namespace MedGestor.Adapter.Driving.Api.AppService;

public class PacienteAppService : IPacienteAppService
{
    private readonly IMapper _mapper;
    private readonly IPacienteService _pacienteService;

    public PacienteAppService(IMapper mapper, IPacienteService pacienteService)
    {
        _mapper = mapper;
        _pacienteService = pacienteService;
    }
    
    public async Task<bool> IncluirPacienteAsync(IncluirPacienteViewModel pacienteViewModel)
    {
        var model = _mapper.Map<Paciente>(pacienteViewModel);
        var pacienteInserido = await _pacienteService.IncluirPacienteAsync(model);
        return pacienteInserido;
    }
}