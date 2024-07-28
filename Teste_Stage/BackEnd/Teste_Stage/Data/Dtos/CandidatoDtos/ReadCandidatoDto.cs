using Teste_Stage.Data.Dtos.EnderecoDtos;
using Teste_Stage.Data.Dtos.EntrevistaDtos;

namespace Teste_Stage.Data.Dtos.CandidatoDtos;

public class ReadCandidatoDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Genero { get; set; }

    public string NumeroContato { get; set; }

    public string Email { get; set; }

    public string Descricao { get; set; }

    public ReadEnderecoDto ReadEnderecoDto { get; set; }

    public ReadEntrevistaDto ReadEntrevistaDto { get; set; }

    public ReadCandidatoDto()
    {
    }

}
