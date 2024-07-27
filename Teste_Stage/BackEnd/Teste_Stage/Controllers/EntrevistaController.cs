using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Teste_Stage.Data;
using Teste_Stage.Data.Dtos;
using Teste_Stage.Models;

namespace Teste_Stage.Controllers;

[ApiController]
[Route("[Controller]")]
public class EntrevistaController : ControllerBase
{
    private EntrevistaContext _context;
    private IMapper _mapper;

    public EntrevistaController(EntrevistaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um entrevista ao banco de dados
    /// </summary>
    /// <param name="entrevistaDto">Objeto com os campos necessários para criação de um entrevista</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastrarEntrevista([FromBody] CreateEntrevistaDto entrevistaDto)
    {

        Entrevista entrevista = _mapper.Map<Entrevista>(entrevistaDto);
        _context.Entrevistas.Add(entrevista);
        _context.SaveChanges();
        return CreatedAtAction(nameof(AchaEntrevistaPorId), new { id = entrevista.Id }, entrevista);

    }

    /// <summary>
    /// Retorna uma lista de entrevistas. Você pode escolher a quantidade de elementos nessa lista.
    /// </summary>
    /// <param name="skip">Número de elementos a pular</param>
    /// <param name="take">Número de elementos a retornar</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadEntrevistaDto> RecuperaEntrevistas([FromQuery] int skip = 0,[FromQuery] int take = 5)
    {
        return _mapper.Map<List<ReadEntrevistaDto>>(_context.Entrevistas.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna uma entrevista específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID da entrevista a ser encontrada</param>
    /// <returns>IActionResult contendo a entrevista encontrada ou um status de NotFound se a entrevista não existir</returns>
    /// <response code="200">Retorna a entrevista encontrada</response>
    /// <response code="404">Se a entrevista não for encontrada</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReadEntrevistaDto), 200)]
    [ProducesResponseType(404)]
    public IActionResult AchaEntrevistaPorId(int id)
    {
        var entrevista = _context.Entrevistas.FirstOrDefault(entrevista => entrevista.Id == id);
        if (entrevista == null)
            return NotFound();
        var entrevistaDto = _mapper.Map<ReadEntrevistaDto>(entrevista);
        return Ok(entrevistaDto);
    }

    /// <summary>
    /// Atualiza uma entrevista específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID da entrevista a ser atualizada</param>
    /// <param name="entrevistaDto">Objeto contendo os dados atualizados da entrevista</param>
    /// <returns>IActionResult indicando o resultado da operação</returns>
    /// <response code="204">Se a atualização for bem-sucedida</response>
    /// <response code="404">Se a entrevista não for encontrada</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult AtualizaEntrevista(int id, [FromBody] UpdateEntrevistaDto entrevistaDto)
    {
        var entrevista = _context.Entrevistas.FirstOrDefault(entrevista => entrevista.Id == id);
        if (entrevista == null) return NotFound();
        _mapper.Map(entrevistaDto, entrevista);
        _context.SaveChanges();
        return NoContent();
    }


    /// <summary>
    /// Deleta uma entrevista específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID da entrevista a ser deletada</param>
    /// <returns>IActionResult indicando o resultado da operação</returns>
    /// <response code="204">Se a exclusão for bem-sucedida</response>
    /// <response code="404">Se a entrevista não for encontrada</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteEntrevista(int id)
    {
        var entrevista = _context.Entrevistas.FirstOrDefault(entrevista => entrevista.Id == id);
        if (entrevista == null) return NotFound();
        _context.Remove(entrevista);
        _context.SaveChanges();
        return NoContent();
    }


}