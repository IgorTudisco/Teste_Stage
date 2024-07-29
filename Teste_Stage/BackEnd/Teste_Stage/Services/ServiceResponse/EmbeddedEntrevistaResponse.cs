namespace Teste_Stage.Services.ServiceResponse;

/// <summary>
/// Representa a resposta contendo uma coleção de entrevistas embutidas.
/// </summary>
public class EmbeddedEntrevistaResponse
{
    /// <summary>
    /// Coleção embutida de entrevistas.
    /// </summary>
    public EmbeddedEntrevista _embedded { get; set; }
}
