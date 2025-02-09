using MedGestor.Adapter.Driven.Database.Mappings;
using MedGestor.Core.Domain.Adapters.Database.UnitOfWork;
using MedGestor.Core.Domain.Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MedGestor.Adapter.Driven.Database.UnitOfWork;

[ExcludeFromCodeCoverage]
public partial class UnitOfWorkContext : DbContext, IUnitOfWorkContext
{
    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<Agenda> Agenda { get; set; }
    public DbSet<Medico> Medico { get; set; }
    public DbSet<Paciente> Paciente { get; set; }
    public DbSet<Perfil> Perfil { get; set; }
    public DbSet<PerfilPermissao> PerfilPermissao { get; set; }
    public DbSet<Permissao> Permissao { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Consulta> Consulta { get; set; }

    private string? _connectionString;
    
    public UnitOfWorkContext(string? connectionString = null) => _connectionString = connectionString;

    public DatabaseFacade GetDatabase() => Database;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AgendaMapping());
        modelBuilder.ApplyConfiguration(new MedicoMapping());
        modelBuilder.ApplyConfiguration(new PessoaMapping());
        modelBuilder.ApplyConfiguration(new UsuarioMapping());
        modelBuilder.ApplyConfiguration(new PacienteMapping());
        modelBuilder.ApplyConfiguration(new PerfilMapping());
        modelBuilder.ApplyConfiguration(new PermissaoMapping());
        modelBuilder.ApplyConfiguration(new PerfilPermissaoMapping());
        modelBuilder.ApplyConfiguration(new ConsultaMapping());
    }
}