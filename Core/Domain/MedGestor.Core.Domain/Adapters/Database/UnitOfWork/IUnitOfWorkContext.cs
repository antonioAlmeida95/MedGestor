using MedGestor.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MedGestor.Core.Domain.Adapters.Database.UnitOfWork;

public interface IUnitOfWorkContext
{
    DbSet<Pessoa> Pessoa { get; }
    DbSet<Agenda> Agenda { get; }
    DbSet<Medico> Medico { get; }
    DbSet<Paciente> Paciente { get; }
    DbSet<Perfil> Perfil { get; }
    DbSet<PerfilPermissao> PerfilPermissao { get; }
    DbSet<Permissao> Permissao { get; }
    DbSet<Usuario> Usuario { get; }
    DbSet<Consulta> Consulta { get; }

    DatabaseFacade GetDatabase();
    
    /// <summary>
    ///     Método para Obtenção da Query setando a tabela do contexto
    /// </summary>
    /// <param name="track">Trackeamento da entidade</param>
    /// <typeparam name="T">Classe Base</typeparam>
    /// <returns>Query</returns>
    IQueryable<T> GetQuery<T>(bool track) where T: class;
    
    /// <summary>
    ///     Método para Obtenção da Query setando a tabela do contexto
    /// </summary>
    /// <typeparam name="T">Classe Base</typeparam>
    /// <returns>Query</returns>
    IQueryable<T> GetQuery<T>() where T: class;
}