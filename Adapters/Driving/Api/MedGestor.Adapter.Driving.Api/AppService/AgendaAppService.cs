using AutoMapper;
using MedGestor.Adapter.Driving.Api.AppService.Interfaces;
using MedGestor.Adapter.Driving.Api.Dtos;
using MedGestor.Core.Domain.Entities;
using MedGestor.Core.Domain.Services;

namespace MedGestor.Adapter.Driving.Api.AppService;

public class AgendaAppService : IAgendaAppService
{
    private readonly IMapper _mapper;
    private readonly IAgendaService _agendaService;

    public AgendaAppService(IMapper mapper, IAgendaService agendaService)
    {
        _mapper = mapper;
        _agendaService = agendaService;
    }
    
    public async Task<bool> IncluirAgendas(IEnumerable<IncluirAgendaViewModel> agendas)
    {
        var models = _mapper.Map<IEnumerable<Agenda>>(agendas);
        var agendasInseridas = await _agendaService.IncluirAgendas(models);

        return agendasInseridas;
    }

    public async Task<bool> AtualizarAgenda(AtualizarAgendaViewModel agenda)
    {
        var model = _mapper.Map<Agenda>(agenda);
        var agendaAtualizada = await _agendaService.AtualizarAgenda(model);

        return agendaAtualizada;
    }

    public async Task<bool> RemoverAgendaPorId(Guid agendaId)
    {
        var agendaRemovida = await _agendaService.RemoverAgendaPorId(agendaId);
        return agendaRemovida;
    }

    public async Task<IEnumerable<AgendaViewModel>> ObterAgendasPorMedicoId(Guid medicoId, int? take = null, int? skip = null)
    {
        var agendas = await _agendaService.ObterAgendasPorMedicoId(medicoId, take, skip);
        return agendas.Any() ? _mapper.Map<IEnumerable<AgendaViewModel>>(agendas) : [];
    }

    public async Task<AgendaViewModel?> ObterAgendaPorId(Guid agendaId)
    {
        var agenda = await _agendaService.ObterAgendaPorId(agendaId);
        return _mapper.Map<AgendaViewModel>(agenda);
    }
}