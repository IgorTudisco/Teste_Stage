using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Teste_Stage.Data.Dtos.CandidatoDtos;
using Teste_Stage.Models;
using Teste_Stage.Services;

namespace Teste_Stage.Controllers;

[ApiController]
[Route("[Controller]")]
public class CandidatoController : ControllerBase
{

    private CandidatoService _candidatoService;

    public CandidatoController(CandidatoService candidatoService)
    {
        _candidatoService = candidatoService;
    }

    /// <summary>
    /// Adiciona um candidato ao banco de dados
    /// </summary>
    /// <param name="candidatoDto">Objeto com os campos necessários para criação de um candidato</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
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
    /// Retorna uma lista de candidatos. Você pode escolher a quantidade de elementos nessa lista.
    /// </summary>
    /// <param name="skip">Número de elementos a pular</param>
    /// <param name="take">Número de elementos a retornar</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadCandidatoDto> RecuperaCandidatos([FromQuery] int skip, [FromQuery] int take)
    {
        return _candidatoService.RecuperaCandidatosService(skip, take);
    }

    /// <summary>
    /// Retorna uma candidato específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID da candidato a ser encontrada</param>
    /// <returns>IActionResult contendo a candidato encontrada ou um status de NotFound se a candidato não existir</returns>
    /// <response code="200">Retorna a candidato encontrada</response>
    /// <response code="404">Se a candidato não for encontrada</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReadCandidatoDto), 200)]
    [ProducesResponseType(404)]
    public IActionResult AchaCandidatoPorId(int id)
    {
        var candidatoAcado = _candidatoService.AchaCandidatoPorIdService(id);
        if (candidatoAcado == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(candidatoAcado);
        }
    }

    /// <summary>
    /// Atualiza um candidato específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do candidato a ser atualizada</param>
    /// <param name="candidatoDto">Objeto contendo os dados atualizados do candidato</param>
    /// <returns>IActionResult indicando o resultado da operação</returns>
    /// <response code="204">Se a atualização for bem-sucedida</response>
    /// <response code="404">Se a candidato não for encontrada</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
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
    /// Deleta um candidato específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do candidato a ser deletada</param>
    /// <returns>IActionResult indicando o resultado da operação</returns>
    /// <response code="204">Se a exclusão for bem-sucedida</response>
    /// <response code="404">Se o candidato não for encontrada</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
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
