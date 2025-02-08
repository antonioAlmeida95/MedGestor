using MedGestor.Core.Application.Service;
using MedGestor.Core.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MedGestor.Core.Application;

public static class MedGestorApplicationDependency
{
    public static void AddMedGestorApplicationModule(this IServiceCollection services)
    {
        services.AddScoped<IAgendaService, AgendaService>();
        services.AddScoped<IMedicoService, MedicoService>();
        services.AddScoped<IPacienteService, PacienteService>();
    }
}