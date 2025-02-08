using MedGestor.Adapter.Driving.Api.AppService;
using MedGestor.Adapter.Driving.Api.AppService.Interfaces;
using MedGestor.Adapter.Driving.Api.Mappings;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MedGestor.Adapter.Driving.Api;

public static class MedGestorApiDependency
{
    public static void AddMedGestorApiModule(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        services.AddScoped<IAgendaAppService, AgendaAppService>();
        services.AddScoped<IMedicoAppService, MedicoAppService>();
        services.AddScoped<IPacienteAppService, PacienteAppService>();
    }
}