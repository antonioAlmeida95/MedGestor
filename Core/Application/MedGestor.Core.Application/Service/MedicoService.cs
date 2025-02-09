using System.Linq.Expressions;
using System.Security.Authentication;
using MedGestor.Core.Application.Models;
using MedGestor.Core.Application.Utils;
using MedGestor.Core.Domain.Adapters.Database.UnitOfWork;
using MedGestor.Core.Domain.Entities;
using MedGestor.Core.Domain.Entities.Constantes;
using MedGestor.Core.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace MedGestor.Core.Application.Service;

public class MedicoService : IMedicoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly CredentialSettings _credentialSettings;

    public MedicoService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        IOptions<CredentialSettings> credentialSettings)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
        _credentialSettings = credentialSettings.Value;
    }
    
    public async Task<bool> IncluirMedico(Medico medico)
    {
        var operacaoValida = await ObterPermissaoParaOperacao();
        if(!operacaoValida) 
            throw new InvalidCredentialException("Usuário sem permissão para operação.");

        await AssociarPerfilMedico(medico);
        MascararSenha(medico);

        return await _unitOfWork.Medico.IncluirMedicoAsync(medico);
    }

    public Task<IEnumerable<Medico>> ObterMedicosPorFiltroAsync(string? especialidade,
        string? nome, string? crm)
    {
        var filtro = CriarPredicate(especialidade, nome, crm);
        return _unitOfWork.Medico.ObterMedicosPorFiltroAsync(filtro);
    }

    private async Task<bool> ObterPermissaoParaOperacao()
    {
        var user = _httpContextAccessor.HttpContext.User?.Identity?.Name;
        ArgumentException.ThrowIfNullOrWhiteSpace(user);

        var pessoa = await _unitOfWork.Pessoa.ObterPessoaPorFiltro(p => p.Usuario.Email.Equals(user));
        return pessoa is not null && pessoa.Perfil.Nome.Equals(Perfis.Administrador);
    }

    private async Task AssociarPerfilMedico(Medico medico)
    {
        var perfil = await _unitOfWork.Perfil.ObterPerfilPorFiltro(p => p.Nome.Equals(Perfis.Medico));
        
        if(perfil is null) return;
        
        medico.Pessoa.AlterarPerfilId(perfil.Id);
    }

    private void MascararSenha(Medico medico)
    {
        var encrypt = BCrypt.Net.BCrypt.HashPassword(medico.Pessoa.Usuario.Senha, _credentialSettings.Salt);
        medico.Pessoa.Usuario.AlterarSenha(encrypt);
    }

    private Expression<Func<Medico, bool>> CriarPredicate(string? especialidade,
        string? nome, string? crm)
    {
        var predicate = ExpressionExtension.Query<Medico>();

        if (!string.IsNullOrEmpty(especialidade))
            predicate = predicate.And(p => p.Especialidade.ToUpper().Contains(especialidade.ToUpper()));

        if (!string.IsNullOrEmpty(nome))
            predicate = predicate.And(p => p.Pessoa.Nome.ToUpper().Contains(nome.ToUpper()));

        if (!string.IsNullOrEmpty(crm))
            predicate = predicate.And(p => p.Crm.Contains(crm));

        return predicate;
    }
}