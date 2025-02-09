using System.Security.Authentication;
using MedGestor.Core.Application.Models;
using MedGestor.Core.Domain.Adapters.Database.UnitOfWork;
using MedGestor.Core.Domain.Entities;
using MedGestor.Core.Domain.Entities.Constantes;
using MedGestor.Core.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace MedGestor.Core.Application.Service;

public class PacienteService : IPacienteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly CredentialSettings _credentialSettings;

    public PacienteService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        IOptions<CredentialSettings> credentialSettings)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
        _credentialSettings = credentialSettings.Value;
    }
    
    public async Task<bool> IncluirPacienteAsync(Paciente paciente)
    {
        var operacaoValida = await ObterPermissaoParaOperacao();
        if(!operacaoValida) 
            throw new InvalidCredentialException("Usuário sem permissão para operação.");

        await AssociarPerfilPaciente(paciente);
        MascararSenha(paciente);

        return await _unitOfWork.Paciente.IncluirPacienteAsync(paciente);
    }
    
    private async Task<bool> ObterPermissaoParaOperacao()
    {
        var user = _httpContextAccessor.HttpContext.User?.Identity?.Name;
        ArgumentException.ThrowIfNullOrWhiteSpace(user);

        var pessoa = await _unitOfWork.Pessoa.ObterPessoaPorFiltro(p => p.Usuario.Email.Equals(user));
        return pessoa is not null && pessoa.Perfil.Nome.Equals(Perfis.Administrador);
    }
    
    private async Task AssociarPerfilPaciente(Paciente paciente)
    {
        var perfil = await _unitOfWork.Perfil.ObterPerfilPorFiltro(p => p.Nome.Equals(Perfis.Paciente));
        
        if(perfil is null) return;
        
        paciente.Pessoa.AlterarPerfilId(perfil.Id);
    }

    private void MascararSenha(Paciente paciente)
    {
        var encrypt = BCrypt.Net.BCrypt.HashPassword(paciente.Pessoa.Usuario.Senha, _credentialSettings.Salt);
        paciente.Pessoa.Usuario.AlterarSenha(encrypt);
    }
}