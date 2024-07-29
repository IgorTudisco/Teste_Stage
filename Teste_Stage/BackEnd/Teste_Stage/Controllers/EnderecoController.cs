using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Teste_Stage.Data.Dtos.EnderecoDtos;
using Teste_Stage.Services;

namespace Teste_Stage.Controllers;

/// <summary>
/// Controlador para gerenciar operações relacionadas a Endereços.
/// </summary>
[ApiController]
[EnableCors("AllowSpecificOrigin")]
[Route("[Controller]")]
public class EnderecoController : ControllerBase
{
    private EnderecoService _enderecoService;

    /// <summary>
    /// Construtor da classe EnderecoController.
    /// </summary>
    /// <param name="enderecoService">Instância do serviço de endereços.</param>
    public EnderecoController(EnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    /// <summary>
    /// Adiciona um endereço ao banco de dados.
    /// </summary>
    /// <param name="enderecoDto">Objeto com os campos necessários para criação de um endereço.</param>
    /// <returns>IActionResult contendo o endereço criado.</returns>
    /// <response code="201">Caso a inserção seja feita com sucesso.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastrarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        var enderecoCadastrado = _enderecoService.CadastrarEnderecoService(enderecoDto);
        return CreatedAtAction(nameof(AchaEnderecoPorId), new { id = enderecoCadastrado.Id }, enderecoCadastrado);
    }

    /// <summary>
    /// Retorna uma lista de endereços. Você pode escolher a quantidade de elementos nessa lista.
    /// </summary>
    /// <param name="skip">Número de elementos a pular.</param>
    /// <param name="take">Número de elementos a retornar.</param>
    /// <returns>IEnumerable contendo os endereços recuperados.</returns>
    /// <response code="200">Caso a lista seja retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadEnderecoDto> RecuperaEnderecos([FromQuery] int skip, [FromQuery] int take)
    {
        return _enderecoService.RecuperaEnderecosService(skip, take);
    }

    /// <summary>
    /// Retorna um endereço específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do endereço a ser encontrado.</param>
    /// <returns>IActionResult contendo o endereço encontrado ou um status de NotFound se o endereço não existir.</returns>
    /// <response code="200">Retorna o endereço encontrado.</response>
    /// <response code="404">Se o endereço não for encontrado.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReadEnderecoDto), 200)]
    [ProducesResponseType(404)]
    public IActionResult AchaEnderecoPorId(int id)
    {
        var enderecoRetornado = _enderecoService.AchaEnderecoPorIdService(id);
        if (enderecoRetornado == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(enderecoRetornado);
        }
    }

    /// <summary>
    /// Atualiza um endereço específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do endereço a ser atualizado.</param>
    /// <param name="enderecoDto">Objeto contendo os dados atualizados do endereço.</param>
    /// <returns>IActionResult indicando o resultado da operação.</returns>
    /// <response code="204">Se a atualização for bem-sucedida.</response>
    /// <response code="404">Se o endereço não for encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var enderecoAtualizado = _enderecoService.AtualizaEnderecoService(id, enderecoDto);
        if (enderecoAtualizado == null)
        {
            return NotFound();
        }
        else
        {
            return NoContent();
        }
    }


    /// <summary>
    /// Deleta um endereço específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do endereço a ser deletado.</param>
    /// <returns>IActionResult indicando o resultado da operação.</returns>
    /// <response code="204">Se a exclusão for bem-sucedida.</response>
    /// <response code="404">Se o endereço não for encontrado.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteEndereco(int id)
    {
        var enderecoDeletado = _enderecoService.DeleteEnderecoService(id);
        if (enderecoDeletado == null)
        {
            return NotFound();
        }
        else
        {
            return NoContent();
        }
    }

}

