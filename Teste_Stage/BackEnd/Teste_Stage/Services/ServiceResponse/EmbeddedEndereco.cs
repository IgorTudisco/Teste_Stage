using Teste_Stage.Data.Dtos.EnderecoDtos;

namespace Teste_Stage.Services.ServiceResponse;

/// <summary>
/// Representa uma coleção embutida de endereço.
/// </summary>
public class EmbeddedEndereco
{
    /// <summary>
    /// Lista de endereço.
    /// </summary>
    public List<ReadEnderecoDto> Endereco { get; set; }
}
