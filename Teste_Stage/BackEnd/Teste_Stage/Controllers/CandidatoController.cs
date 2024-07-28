using AutoMapper;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Teste_Stage.Data;
using Teste_Stage.Data.Dtos.CandidatoDtos;
using Teste_Stage.Models;

namespace Teste_Stage.Controllers;

[ApiController]
[Route("[Controller]")]
public class CandidatoController : ControllerBase
{

    private CandidatoContext _context;
    private IMapper _mapper;

    public CandidatoController(CandidatoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

        Candidato candidato = _mapper.Map<Candidato>(candidatoDto);
        _context.Candidatos.Add(candidato);
        _context.SaveChanges();
        return CreatedAtAction(nameof(AchaCandidatoPorId), new { id = candidato.Id }, candidato);

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
    public IEnumerable<ReadCandidatoDto> RecuperaCandidatos([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _mapper.Map<List<ReadCandidatoDto>>(_context.Candidatos.ToList().Skip(skip).Take(take));
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
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
        if (candidato == null)
            return NotFound();
        var candidatoDto = _mapper.Map<ReadCandidatoDto>(candidato);
        return Ok(candidatoDto);
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
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
        if (candidato == null) return NotFound();

        if (candidato.EnderecoId != candidatoDto.EnderecoId)
        {
            var candidatoEndereco = _context.Candidatos.FirstOrDefault(candidato => candidato.EnderecoId == candidatoDto.EnderecoId);
            if (candidatoEndereco != null)
            {
                return BadRequest(candidatoEndereco.EnderecoId);
                // return BadRequest("Id endereço invalido " + candidatoEndereco.EnderecoId);
            }
            else
            {
                // Achando o id de "enderecoId" para atualizar para um endereço não nulo.
                var endereco = _context.Enderecos.Where(endereco => endereco.Id == candidatoDto.EnderecoId).ToList();
                if (endereco.IsNullOrEmpty()) return NotFound();
            }
        }

        // Achando o id de "entrevistaId" para atualizar para uma entrevista não nulo.
        var entrevista = _context.Entrevistas.Where(entrevista => entrevista.Id == candidatoDto.EntrevistaId).ToList();
        if (entrevista.IsNullOrEmpty()) return NotFound();

        _mapper.Map(candidatoDto, candidato);
        _context.SaveChanges();
        return NoContent();
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
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
        if (candidato == null)return NotFound();
        _context.Remove(candidato);
        _context.SaveChanges();
        return NoContent();
    }
}
