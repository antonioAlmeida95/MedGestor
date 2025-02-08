using AutoMapper;
using MedGestor.Adapter.Driving.Api.AppService.Interfaces;
using MedGestor.Adapter.Driving.Api.Dtos;
using MedGestor.Core.Domain.Entities;
using MedGestor.Core.Domain.Services;

namespace MedGestor.Adapter.Driving.Api.AppService;

public class MedicoAppService : IMedicoAppService
{
    private readonly IMapper _mapper;
    private readonly IMedicoService _medicoService;

    public MedicoAppService(IMapper mapper, IMedicoService medicoService)
    {
        _mapper = mapper;
        _medicoService = medicoService;
    }
    
    public async Task<bool> IncluirMedicoAsync(IncluirMedicoViewModel medicoViewModel)
    {
        var model = _mapper.Map<Medico>(medicoViewModel);
        var medicoInserido = await _medicoService.IncluirMedico(model);
        return medicoInserido;
    }
}