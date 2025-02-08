using System.Security.Authentication;
using MedGestor.Core.Domain.Adapters.Database.UnitOfWork;
using MedGestor.Core.Domain.Entities;
using MedGestor.Core.Domain.Entities.Constantes;
using MedGestor.Core.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace MedGestor.Core.Application.Service;

public class MedicoService : IMedicoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MedicoService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<bool> IncluirMedico(Medico medico)
    {
        var operacaoValida = await ObterPermissaoParaOperacao();
        if(!operacaoValida) 
            throw new InvalidCredentialException("Usuário sem permissão para operação.");

        return await _unitOfWork.Medico.IncluirMedicoAsync(medico);
    }
    
    private async Task<bool> ObterPermissaoParaOperacao()
    {
        var user = _httpContextAccessor.HttpContext.User?.Identity?.Name;
        ArgumentException.ThrowIfNullOrWhiteSpace(user);

        var pessoa = await _unitOfWork.Pessoa.ObterPessoaPorFiltro(p => p.Usuario.Email.Equals(user));
        return pessoa is not null && pessoa.Perfil.Nome.Equals(Perfis.Administrador);
    }
}