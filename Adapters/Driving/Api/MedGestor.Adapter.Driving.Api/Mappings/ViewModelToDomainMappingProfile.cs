using AutoMapper;
using MedGestor.Adapter.Driving.Api.Dtos;
using MedGestor.Core.Domain.Entities;

namespace MedGestor.Adapter.Driving.Api.Mappings;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<IncluirAgendaViewModel, Agenda>();
        CreateMap<AtualizarAgendaViewModel, Agenda>()
            .ForMember(s => s.Id, opt => opt.MapFrom(src => src.AgendaId))
            .AfterMap((src, des) =>
            {
                des.Id = src.AgendaId;
            });;

        CreateMap<IncluirMedicoViewModel, Medico>();
        CreateMap<IncluirPacienteViewModel, Paciente>();
        CreateMap<PessoaViewModel, Pessoa>();
        CreateMap<UsuarioViewModel, Usuario>();
    }
}