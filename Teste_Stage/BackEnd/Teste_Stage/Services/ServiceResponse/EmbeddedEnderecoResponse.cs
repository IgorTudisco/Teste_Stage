namespace Teste_Stage.Services.ServiceResponse;

/// <summary>
/// Representa a resposta contendo uma coleção de endereço embutidas.
/// </summary>
public class EmbeddedEnderecoResponse
{
    /// <summary>
    /// Coleção embutida de endereço.
    /// </summary>
    public EmbeddedEndereco _embedded { get; set; }
}
