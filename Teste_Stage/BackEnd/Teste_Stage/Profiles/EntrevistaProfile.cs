using AutoMapper;
using Teste_Stage.Data.Dtos.EntrevistaDtos;
using Teste_Stage.Models;

namespace Teste_Stage.Profiles;

public class EntrevistaProfile : Profile
{
    public EntrevistaProfile()
    {
        CreateMap<CreateEntrevistaDto, Entrevista>();
        CreateMap<UpdateEntrevistaDto, Entrevista>();
        CreateMap<Entrevista, UpdateEntrevistaDto>();
        CreateMap<Entrevista, ReadEntrevistaDto>()
            .ForMember(entrevistaDto => entrevistaDto.ReadCandidatoDto, opt =>
            opt.MapFrom(entrevista => entrevista.Candidato))
            ;
    }
}
