using MedGestor.Core.Domain.Adapters.Database.Repository;

namespace MedGestor.Core.Domain.Adapters.Database.UnitOfWork;

public interface IUnitOfWork
{
    IAgendaRepository Agenda { get; }
    IMedicoRepository Medico { get; }
    IPacienteRepository Paciente { get; }
    IPerfilRepository Perfil { get; }
    IPessoaRepository Pessoa { get; }
    IConsultaRepository Consulta { get; }
}