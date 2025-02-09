using System.Security.Authentication;
using MedGestor.Core.Domain.Adapters.Database.UnitOfWork;
using MedGestor.Core.Domain.Entities;
using MedGestor.Core.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MedGestor.Core.Application.Service;
public class AgendaService : IAgendaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AgendaService> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private const string Medico = "Medico";

    public AgendaService(IUnitOfWork unitOfWork,
        ILogger<AgendaService> logger,
        IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<bool> IncluirAgendas(IEnumerable<Agenda> agendas)
    {
        var medicoId = await ObterUsuarioLogadoId();
        
        if (medicoId == Guid.Empty) return false;
        
        var agendasLista = agendas.ToList();
        agendasLista.AsParallel().ForAll(s => s.AlterarMedicoId(medicoId));

        return await _unitOfWork.Agenda.AdicionarListagemAgendaAsync(agendasLista);
    }

    public async Task<bool> AtualizarAgenda(Agenda agenda)
    {
        var medicoId = await ObterUsuarioLogadoId();
        
        if(medicoId == Guid.Empty || medicoId != agenda.MedicoId)
            throw new InvalidCredentialException("Usuário sem permissão para operação.");

        return await _unitOfWork.Agenda.AtualizarAgenda(agenda);
    }

    public async Task<bool> RemoverAgendaPorId(Guid agendaId)
    {
        var medicoId = await ObterUsuarioLogadoId();
        if (medicoId == Guid.Empty) return false;

        var agenda = await _unitOfWork.Agenda.ObterAgendaPorFiltroAsync(a => a.Id == agendaId
                                                                             && a.MedicoId == medicoId, track: true);

        if (agenda is null) return false;

        return await _unitOfWork.Agenda.RemoverAgenda(agenda);
    }

    public async Task<IEnumerable<Agenda>> ObterAgendasPorMedicoId(Guid medicoId, int? take = null, int? skip = null)
    {
        var medicoLogadoId = await ObterUsuarioLogadoId();

        if (medicoId == Guid.Empty) return [];
        
        if(medicoLogadoId != medicoId)
            throw new InvalidCredentialException("Usuário sem permissão para operação.");

        return await _unitOfWork.Agenda.ObterListagemAgendaPorFiltroAsync(a => a.MedicoId == medicoId, take: take,
            skip: skip, track: false);
    }

    public async Task<Agenda?> ObterAgendaPorId(Guid agendaId)
    {
        var medicoLogadoId = await ObterUsuarioLogadoId();

        if (medicoLogadoId == Guid.Empty) return null;

        var agenda = await _unitOfWork.Agenda.ObterAgendaPorFiltroAsync(a => a.Id == agendaId);
        
        if (agenda is not null && agenda.MedicoId != medicoLogadoId)
            throw new InvalidCredentialException("Usuário sem permissão para operação.");

        return agenda;
    }

    private async Task<Guid> ObterUsuarioLogadoId()
    {
        var user = _httpContextAccessor.HttpContext.User?.Identity?.Name;
        ArgumentException.ThrowIfNullOrWhiteSpace(user);

        var medico = await _unitOfWork.Medico.ObterMedicoPorFiltroAsync(m => m.Pessoa.Usuario.Email.Contains(user));

        return medico?.Id ?? Guid.Empty;
    }
}