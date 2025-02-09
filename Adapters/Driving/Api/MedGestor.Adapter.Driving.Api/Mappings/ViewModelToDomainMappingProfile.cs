using AutoMapper;
using MedGestor.Adapter.Driving.Api.Dtos;
using MedGestor.Core.Domain.Entities;

namespace MedGestor.Adapter.Driving.Api.Mappings;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<IncluirAgendaViewModel, Agenda>()
            .ForMember(x => x.DataFim, opt => opt.MapFrom(src => src.DataFim.UtcDateTime))
            .ForMember(x => x.DataInicio, opt => opt.MapFrom(src => src.DataInicio.UtcDateTime));
        
        CreateMap<AtualizarAgendaViewModel, Agenda>()
            .ForMember(s => s.Id, opt => opt.MapFrom(src => src.AgendaId))
            .AfterMap((src, des) =>
            {
                des.Id = src.AgendaId;
            });;

        CreateMap<IncluirMedicoViewModel, Medico>()
            .ForMember(s => s.Status, opt => opt.MapFrom(src => true));
        CreateMap<IncluirPacienteViewModel, Paciente>();
        CreateMap<PessoaViewModel, Pessoa>();
        CreateMap<UsuarioViewModel, Usuario>()
            .ForMember(s => s.Status, opt => opt.MapFrom(src => true));
    }
}