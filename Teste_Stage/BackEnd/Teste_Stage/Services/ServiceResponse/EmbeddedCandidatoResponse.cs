namespace Teste_Stage.Services.ServiceResponse;

/// <summary>
/// Representa a resposta contendo uma coleção de candidatos embutidas.
/// </summary>
public class EmbeddedCandidatoResponse
{
    /// <summary>
    /// Coleção embutida de candidato.
    /// </summary>
    public EmbeddedCandidato _embedded { get; set; }
}
