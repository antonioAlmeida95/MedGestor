using MedGestor.Adapter.Driven.Database.Repository;
using MedGestor.Adapter.Driven.Database.UnitOfWork;
using MedGestor.Core.Domain.Adapters.Database.Repository;
using MedGestor.Core.Domain.Adapters.Database.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkInstance = MedGestor.Adapter.Driven.Database.UnitOfWork.UnitOfWork;

namespace MedGestor.Adapter.Driven.Database;

public static class MedGestorDatabaseDependency
{
    public static void AddMedGestorDatabaseModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWorkInstance>();
        services.AddScoped(_ =>
        {
            var connectionString = GetConnectionString(configuration);
            var context = new UnitOfWorkContext(connectionString);
            
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();
            
            return context;
        });
        
        services.AddScoped<IAgendaRepository, AgendaRepository>();
        services.AddScoped<IMedicoRepository, MedicoRepository>();
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<IPerfilRepository, PerfilRepository>();
        services.AddScoped<IPessoaRepository, PessoaRepository>();
        services.AddScoped<IConsultaRepository, ConsultaRepositoy>();
    }
    
    private static string? GetConnectionString(IConfiguration configuration)
    {
        var connectionStringName = "DefaultConnection";
       
        #if !DEBUG
        connectionStringName = "DockerConnection";
        #endif

        return configuration.GetConnectionString(connectionStringName);
    }
}