using Teste_Stage.Data.Dtos.EntrevistaDtos;

namespace Teste_Stage.Services.ServiceResponse;

/// <summary>
/// Representa uma coleção embutida de entrevistas.
/// </summary>
public class EmbeddedEntrevista
{
    /// <summary>
    /// Lista de entrevistas.
    /// </summary>
    public List<ReadEntrevistaDto> Entrevistas { get; set; }

}
