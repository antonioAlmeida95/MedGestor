using AutoMapper;
using MedGestor.Adapter.Driving.Api.Dtos;
using MedGestor.Core.Domain.Entities;

namespace MedGestor.Adapter.Driving.Api.Mappings;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Agenda, AgendaViewModel>()
            .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Medico.Pessoa.Nome))
            .ForMember(x => x.Especialidade, opt => opt.MapFrom(src => src.Medico.Especialidade))
            .ForMember(x => x.MedicoId, opt=> opt.MapFrom(src => src.MedicoId))
            .ForMember(x => x.AgendaId, opt=> opt.MapFrom(src => src.Id));

        CreateMap<Agenda, AtualizarAgendaViewModel>()
            .ForMember(x => x.AgendaId, opt => opt.MapFrom(src => src.Id));

        CreateMap<Agenda, AgendaSimplificada>()
            .ForMember(x => x.AgendaId, opt=> opt.MapFrom(src => src.Id));
        
        CreateMap<Medico, MedicoViewModel>()
            .ForMember(x => x.MedicoId, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Pessoa.Nome));

        CreateMap<Paciente, PacienteSimplificadoViewModel>()
            .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Pessoa.Nome))
            .ForMember(x => x.DataNascimento, opt => opt.MapFrom(src => src.Pessoa.DataNascimento))
            .ForMember(x => x.Genero, opt => opt.MapFrom(src => src.Pessoa.Genero));

        CreateMap<Consulta, ConsultaViewModel>()
            .ForMember(x => x.ConsultaId, opt => opt.MapFrom(src => src.Id));
    }
}