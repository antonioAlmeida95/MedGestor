using MedGestor.Core.Application.Models;
using MedGestor.Core.Application.Service;
using MedGestor.Core.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedGestor.Core.Application;

public static class MedGestorApplicationDependency
{
    public static void AddMedGestorApplicationModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CredentialSettings>(opt => configuration.GetSection("Credentials:Secret").Bind(opt));

        services.AddScoped<IAgendaService, AgendaService>();
        services.AddScoped<IMedicoService, MedicoService>();
        services.AddScoped<IPacienteService, PacienteService>();
        services.AddScoped<IConsultaService, ConsultaService>();
    }
}