using Castle.Core.Internal;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Teste_Stage.Data.Dtos.CandidatoDtos;
using Teste_Stage.Models;
using Teste_Stage.Services;
using Teste_Stage.Services.ServiceResponse;

namespace Teste_Stage.Controllers;

/// <summary>
/// Controlador para gerenciar as operações relacionadas a candidatos.
/// </summary>
[ApiController]
[EnableCors("AllowSpecificOrigin")]
[Route("[Controller]")]
public class CandidatoController : ControllerBase
{

    private CandidatoService _candidatoService;

    /// <summary>
    /// Inicializa uma nova instância do controlador de candidatos.
    /// </summary>
    /// <param name="candidatoService">Serviço utilizado para operações de candidatos.</param>
    public CandidatoController(CandidatoService candidatoService)
    {
        _candidatoService = candidatoService;
    }

    /// <summary>
    /// Adiciona um novo candidato ao banco de dados.
    /// </summary>
    /// <param name="candidatoDto">Objeto contendo os dados necessários para criar um novo candidato.</param>
    /// <returns>Retorna um status HTTP indicando o resultado da operação.</returns>
    /// <response code="201">Se o candidato for criado com sucesso.</response>
    /// <response code="400">Se o endereço fornecido for inválido ou já existir.</response>
    /// <response code="404">Se algum dos IDs fornecidos no DTO for nulo.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult CadastrarCandidato([FromBody] CreateCandidatoDto candidatoDto)
    {
        var serviceCandidato = _candidatoService;
        
        string? verificaEnderecoIdDuplicado = serviceCandidato.VerificaEnderecoIdDuplicado(candidatoDto);
        string? verificaIdNull = serviceCandidato.VerificaIdNullo(candidatoDto);

        if (verificaEnderecoIdDuplicado.IsNullOrEmpty())
        {
            return BadRequest(candidatoDto.EnderecoId);
        }

        if (verificaIdNull.IsNullOrEmpty())
        {
            return NotFound();
        }

        Candidato candidatoCadastrado = serviceCandidato.CadastrarCandidatoService(candidatoDto);
        return CreatedAtAction(nameof(AchaCandidatoPorId), new { id = candidatoCadastrado.Id }, candidatoCadastrado);

    }

    /// <summary>
    /// Retorna uma lista de candidatos com paginação. Você pode especificar a quantidade de elementos a serem retornados e pular uma quantidade específica de elementos.
    /// </summary>
    /// <param name="skip">Número de elementos a pular na lista de candidatos.</param>
    /// <param name="take">Número de elementos a serem retornados na resposta.</param>
    /// <returns>Um objeto `EmbeddedCandidatoResponse` contendo a lista de candidatos.</returns>
    /// <response code="200">Caso a lista de candidatos seja retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmbeddedCandidatoResponse))]
    public IActionResult RecuperaCandidatos([FromQuery] int skip, [FromQuery] int take)
    {
        var candidato = _candidatoService.RecuperaCandidatosService(skip, take).ToList();
        var response = new EmbeddedCandidatoResponse
        {
            _embedded = new EmbeddedCandidato
            {
                Candidato = candidato
            }
        };
        return Ok(response);
    }

    /// <summary>
    /// Retorna um candidato específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do candidato a ser retornado.</param>
    /// <returns>O candidato correspondente ao ID fornecido ou um status HTTP de NotFound se o candidato não existir.</returns>
    /// <response code="200">Retorna o candidato encontrado.</response>
    /// <response code="404">Se o candidato com o ID fornecido não for encontrado.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReadCandidatoDto), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AchaCandidatoPorId(int id)
    {
        var candidatoRetornado = _candidatoService.AchaCandidatoPorIdService(id);
        if (candidatoRetornado == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(candidatoRetornado);
        }
    }

    /// <summary>
    /// Atualiza as informações de um candidato específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do candidato a ser atualizado.</param>
    /// <param name="candidatoDto">Objeto contendo os dados atualizados do candidato.</param>
    /// <returns>Um status HTTP indicando o resultado da operação.</returns>
    /// <response code="204">Se a atualização for bem-sucedida.</response>
    /// <response code="400">Se o endereço fornecido for inválido.</response>
    /// <response code="404">Se o candidato com o ID fornecido não for encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AtualizaCandidato(int id, [FromBody] UpdateCandidatoDto candidatoDto)
    {
        var candidatoAtualizado = _candidatoService.AtualizaCandidatoService(id, candidatoDto);

        switch (candidatoAtualizado)
        {
            case 0:
                return NoContent();
            case 1:
                return BadRequest(candidatoDto.EnderecoId);
            // return BadRequest("Id endereço invalido " + candidatoEndereco.EnderecoId);
            default:
                return NotFound();
        }
    }

    /// <summary>
    /// Deleta um candidato específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do candidato a ser deletado.</param>
    /// <returns>Um status HTTP indicando o resultado da operação.</returns>
    /// <response code="204">Se a exclusão for bem-sucedida.</response>
    /// <response code="404">Se o candidato com o ID fornecido não for encontrado.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteCandidato(int id)
    {
        var candidatoDeletado = _candidatoService.DeleteCandidatoService(id);
        if (candidatoDeletado == null)
        {
            return NotFound();
        }
        else
        {
            return NoContent();
        }
    }
}
