namespace Teste_Stage.Data.Dtos.CandidatoDtos;

public class UpdateCandidatoDto
{
    public string Name { get; set; }

    public string Genero { get; set; }

    public int Idade { get; set; }

    public string NumeroContato { get; set; }

    public string Email { get; set; }

    public string Descricao { get; set; }

    public int EnderecoId { get; set; }

    public int EntrevistaId { get; set; }

    public UpdateCandidatoDto()
    {
    }

}
