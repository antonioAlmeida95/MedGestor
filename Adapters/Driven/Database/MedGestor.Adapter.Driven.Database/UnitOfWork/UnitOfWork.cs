using MedGestor.Core.Domain.Adapters.Database.Repository;
using MedGestor.Core.Domain.Adapters.Database.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace MedGestor.Adapter.Driven.Database.UnitOfWork;

public class UnitOfWork(IServiceProvider serviceProvider) : IUnitOfWork
{
    public IAgendaRepository Agenda => serviceProvider.GetRequiredService<IAgendaRepository>();
    public IMedicoRepository Medico => serviceProvider.GetRequiredService<IMedicoRepository>();
    public IPacienteRepository Paciente => serviceProvider.GetRequiredService<IPacienteRepository>();
    public IPerfilRepository Perfil => serviceProvider.GetRequiredService<IPerfilRepository>();
    public IPessoaRepository Pessoa => serviceProvider.GetRequiredService<IPessoaRepository>();
    public IConsultaRepository Consulta => serviceProvider.GetRequiredService<IConsultaRepository>();
}