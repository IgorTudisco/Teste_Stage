using AutoMapper;
using Teste_Stage.Data.Dtos.EnderecoDtos;
using Teste_Stage.Models;

namespace Teste_Stage.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
        CreateMap<UpdateEnderecoDto, Endereco>();
    }

}
