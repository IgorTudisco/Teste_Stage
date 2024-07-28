using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teste_Stage.Data.Dtos.EnderecoDtos;
using Teste_Stage.Data;
using Teste_Stage.Models;

namespace Teste_Stage.Controllers;

[ApiController]
[Route("[Controller]")]
public class EnderecoController : ControllerBase
{
    private CandidatoContext _context;
    private IMapper _mapper;

    public EnderecoController(CandidatoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um endereco ao banco de dados
    /// </summary>
    /// <param name="enderecoDto">Objeto com os campos necessários para criação de um endereco</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastrarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {

        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(AchaEnderecoPorId), new { id = endereco.Id }, endereco);

    }

    /// <summary>
    /// Retorna uma lista de enderecos. Você pode escolher a quantidade de elementos nessa lista.
    /// </summary>
    /// <param name="skip">Número de elementos a pular</param>
    /// <param name="take">Número de elementos a retornar</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadEnderecoDto> Recuperaenderecos([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna um endereco específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do endereco a ser encontrada</param>
    /// <returns>IActionResult contendo o endereco encontrada ou um status de NotFound se o endereco não existir</returns>
    /// <response code="200">Retorna a endereco encontrada</response>
    /// <response code="404">Se a endereco não for encontrada</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReadEnderecoDto), 200)]
    [ProducesResponseType(404)]
    public IActionResult AchaEnderecoPorId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
            return NotFound();
        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    /// <summary>
    /// Atualiza uma endereco específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do endereco a ser atualizada</param>
    /// <param name="enderecoDto">Objeto contendo os dados atualizados do endereco</param>
    /// <returns>IActionResult indicando o resultado da operação</returns>
    /// <response code="204">Se a atualização for bem-sucedida</response>
    /// <response code="404">Se a endereco não for encontrada</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }


    /// <summary>
    /// Deleta uma endereco específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do endereco a ser deletada</param>
    /// <returns>IActionResult indicando o resultado da operação</returns>
    /// <response code="204">Se a exclusão for bem-sucedida</response>
    /// <response code="404">Se o endereco não for encontrada</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        // Desassocia os candidatos do endereço
        var candidatos = _context.Candidatos.Where(candidatos => candidatos.EnderecoId == id).ToList();
        foreach (var candidato in candidatos)
            candidato.EnderecoId = null;
        _context.SaveChanges();

        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }

}

