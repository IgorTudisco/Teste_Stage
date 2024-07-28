using Teste_Stage.Data.Dtos.CandidatoDtos;

namespace Teste_Stage.Data.Dtos.EntrevistaDtos;

public class ReadEntrevistaDto
{
    public int Id { get; set; }

    public string Cargo { get; set; }

    public string FitCultral { get; set; }

    public bool TesteFeito { get; set; }

    public float PontuacaoTest { get; set; }

    public ICollection<ReadCandidatoDto> ReadCandidatoDto { get; set; }

    public ReadEntrevistaDto()
    {
    }

}
