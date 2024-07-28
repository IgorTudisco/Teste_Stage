using AutoMapper;
using Teste_Stage.Data.Dtos.CandidatoDtos;
using Teste_Stage.Models;

namespace Teste_Stage.Profiles;

public class CandidatoProfile : Profile
{
    public CandidatoProfile()
    {
        CreateMap<CreateCandidatoDto, Candidato>();

        CreateMap<Candidato, ReadCandidatoDto>()
            
            .ForMember(candidatoDto => candidatoDto.ReadEnderecoDto, opt =>
            opt.MapFrom(candidato => candidato.Endereco))
            
            .ForMember(candidatoDto => candidatoDto.ReadEntrevistaDto, opt =>
            opt.MapFrom(candidato => candidato.Entrevista));

        CreateMap<UpdateCandidatoDto, Candidato>();
    }
}
