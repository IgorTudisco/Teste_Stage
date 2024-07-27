using Teste_Stage.Data.Dtos.EnderecoDtos;

namespace Teste_Stage.Data.Dtos.CandidatoDtos;

public class ReadCandidatoDto
{
    public string Name { get; set; }

    public string Genero { get; set; }

    public string NumeroContato { get; set; }

    public string Email { get; set; }

    public string Descricao { get; set; }

    public ReadEnderecoDto ReadEnderecoDto { get; set; }

    public ReadCandidatoDto()
    {
    }

}
