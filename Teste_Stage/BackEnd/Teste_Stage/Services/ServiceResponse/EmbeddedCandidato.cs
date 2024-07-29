using Teste_Stage.Data.Dtos.CandidatoDtos;

namespace Teste_Stage.Services.ServiceResponse;

/// <summary>
/// Representa uma coleção embutida de candidato.
/// </summary>
public class EmbeddedCandidato
{
    /// <summary>
    /// Lista de candidato.
    /// </summary>
    public List<ReadCandidatoDto> Candidato { get; set; }
}
