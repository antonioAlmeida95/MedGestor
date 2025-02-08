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
            .ForMember(x => x.Especialidade, opt => opt.MapFrom(src => src.Medico.Especialidade));

        CreateMap<Agenda, AtualizarAgendaViewModel>()
            .ForMember(x => x.AgendaId, opt => opt.MapFrom(src => src.Id));
    }
}