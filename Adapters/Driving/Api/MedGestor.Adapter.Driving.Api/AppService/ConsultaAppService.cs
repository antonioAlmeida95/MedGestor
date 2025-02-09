using AutoMapper;
using MedGestor.Adapter.Driving.Api.AppService.Interfaces;
using MedGestor.Adapter.Driving.Api.Dtos;
using MedGestor.Core.Domain.Entities;
using MedGestor.Core.Domain.Services;

namespace MedGestor.Adapter.Driving.Api.AppService;

public class ConsultaAppService : IConsultaAppService
{
    private readonly IMapper _mapper;
    private readonly IConsultaService _consultaService;

    public ConsultaAppService(IMapper mapper, IConsultaService consultaService)
    {
        _mapper = mapper;
        _consultaService = consultaService;
    }
    
    public async Task<bool> IncluirConsultaAsync(Guid agendaId)
    {
        var consulta = new Consulta(agendaId: agendaId, Guid.Empty);
        return await _consultaService.IncluirConsultaAsync(consulta);
    }

    public async Task<bool> AceitarRecusarConsultaAsync(Guid consultaId, bool aceite)
        => await _consultaService.AceiteRecusaConsulta(consultaId, aceite);


    public async Task<bool> CancelarConsultaAsync(CancelarConsultaViewModel cancelarConsultaViewModel)
        => await _consultaService.CancelarConsultaAsync(cancelarConsultaViewModel.ConsultaId,
            cancelarConsultaViewModel.Justificativa);

    public async Task<IEnumerable<ConsultaViewModel>> ObterConsultasPorFiltrosAsync(Guid? medicoId = null,
        Guid? pacienteId = null)
    {
        var consultas = await _consultaService.ObterConsultasPorFiltroAsync(medicoId, pacienteId);
        return _mapper.Map<IEnumerable<ConsultaViewModel>>(consultas);
    }
}