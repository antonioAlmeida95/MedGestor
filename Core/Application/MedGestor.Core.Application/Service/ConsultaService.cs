using System.Security.Authentication;
using MedGestor.Core.Domain.Adapters.Database.UnitOfWork;
using MedGestor.Core.Domain.Entities;
using MedGestor.Core.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace MedGestor.Core.Application.Service;

public class ConsultaService : IConsultaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ConsultaService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> IncluirConsultaAsync(Consulta consulta)
    {
        var pacienteLogadoId = await ObterPacienteLogadoId();
        if (pacienteLogadoId == Guid.Empty)
            throw new InvalidCredentialException("Usuário sem permissão para operação.");

        consulta.AlterarPacienteId(pacienteLogadoId);

        return await _unitOfWork.Consulta.IncluirConsultaAsync(consulta);
    }

    public async Task<bool> CancelarConsultaAsync(Guid consultaId, string? justificativa)
    {
        var consultas = await _unitOfWork.Consulta.ObterConsultasPorFiltro(c => c.Id == consultaId, track: true);
        consultas = consultas.ToList();

        if (!consultas.Any()) return false;

        var pacienteLogadoId = await ObterPacienteLogadoId();
        var consulta = consultas.FirstOrDefault();

        if (consulta is null || consulta.PacienteId != pacienteLogadoId)
            throw new InvalidCredentialException("Usuário sem permissão para operação.");

        consulta.AlterarCancelamento(true);
        consulta.AlterarJustificativa(justificativa ?? string.Empty);

        return await _unitOfWork.Consulta.AtualizarConsulta(consulta);
    }

    public async Task<bool> AceiteRecusaConsulta(Guid consultaId, bool aceite)
    {
        var consultas = await _unitOfWork.Consulta.ObterConsultasPorFiltro(c => c.Id == consultaId
            && !c.Cancelada, track: true);
        consultas = consultas.ToList();

        if (!consultas.Any()) return false;

        var medicoLogadoId = await ObterMedicoLogadoId();
        var consulta = consultas.FirstOrDefault();

        if (consulta is null || consulta.Agenda.MedicoId != medicoLogadoId)
            throw new InvalidCredentialException("Usuário sem permissão para operação.");

        consulta.AlterarAceite(aceite);
        return await _unitOfWork.Consulta.AtualizarConsulta(consulta);
    }

    public async Task<IEnumerable<Consulta>> ObterConsultasPorFiltroAsync(Guid? medicoId = null, Guid? pacienteId = null)
    {
        if (medicoId != null && pacienteId == null) return await ConsultasPorMedicoAsync(medicoId.Value);
        if (pacienteId != null) return await ConsultasPorPacienteAsync(pacienteId.Value);
        return [];
    }

    private async Task<IEnumerable<Consulta>> ConsultasPorMedicoAsync(Guid medicoId)
        => await _unitOfWork.Consulta.ObterConsultasPorFiltro(c => c.Agenda.MedicoId == medicoId);
    
    private async Task<IEnumerable<Consulta>> ConsultasPorPacienteAsync(Guid? pacienteId)
        => await _unitOfWork.Consulta.ObterConsultasPorFiltro(c => c.PacienteId == pacienteId);

    private async Task<Guid> ObterPacienteLogadoId()
    {
        var user = _httpContextAccessor.HttpContext.User?.Identity?.Name;
        ArgumentException.ThrowIfNullOrWhiteSpace(user);

        var paciente =
            await _unitOfWork.Paciente.ObterPacientePorFiltroAsync(m => m.Pessoa.Usuario.Email.Contains(user));

        return paciente?.Id ?? Guid.Empty;
    }

    private async Task<Guid> ObterMedicoLogadoId()
    {
        var user = _httpContextAccessor.HttpContext.User?.Identity?.Name;
        ArgumentException.ThrowIfNullOrWhiteSpace(user);

        var medico = await _unitOfWork.Medico.ObterMedicoPorFiltroAsync(m => m.Pessoa.Usuario.Email.Contains(user));

        return medico?.Id ?? Guid.Empty;
    }
}