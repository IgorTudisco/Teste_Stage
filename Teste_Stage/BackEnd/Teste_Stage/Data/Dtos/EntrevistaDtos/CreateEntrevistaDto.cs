using Teste_Stage.Models;

namespace Teste_Stage.Data.Dtos.EntrevistaDtos;

public class CreateEntrevistaDto
{
    public int CandidatoId { get; set; }

    public string Cargo { get; set; }

    public int Idade { get; set; }

    public string FitCultral { get; set; }

    public bool TesteFeito { get; set; }

    public float PontuacaoTest { get; set; }

    public CreateEntrevistaDto()
    {
    }

}
