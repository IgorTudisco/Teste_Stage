using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpPost]
    public IActionResult CadastrarEntrevista([FromBody] CreateEntrevistaDto entrevistaDto)
    {

        Entrevista entrevista = _mapper.Map<Entrevista>(entrevistaDto);
        _context.Entrevistas.Add(entrevista);
        _context.SaveChanges();
        return CreatedAtAction(nameof(AchaEntrevistaPorId), new { id = entrevista.Id }, entrevista);

    }

    [HttpGet]
    public IEnumerable<Entrevista> RecuperaEntrevistas([FromQuery] int skip = 0,[FromQuery] int take = 5)
    {
        return _context.Entrevistas.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult AchaEntrevistaPorId(int id)
    {

        var filme = _context.Entrevistas.FirstOrDefault(entrevista => entrevista.Id == id);
        if(filme == null) return NotFound();
        return Ok(filme);

    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEntrevista(int id, [FromBody] UpdateEntrevistaDto entrevistaDto)
    {
        var entrevista = _context.Entrevistas.FirstOrDefault(entrevista => entrevista.Id == id);
        if(entrevista == null) return NotFound();
        _mapper.Map(entrevistaDto, entrevista);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaParcialEntrevista(int id, JsonPatchDocument<UpdateEntrevistaDto> patchEntrevista)
    {
        var entrevista = _context.Entrevistas.FirstOrDefault(entrevista => entrevista.Id == id);
        if (entrevista == null)
            return NotFound();

        var entrevistaParaAtualizar = _mapper.Map<UpdateEntrevistaDto>(entrevista);

        patchEntrevista.ApplyTo(entrevistaParaAtualizar, ModelState);

        if (!TryValidateModel(entrevistaParaAtualizar))
            return ValidationProblem(ModelState);

        _mapper.Map(entrevistaParaAtualizar, entrevista);
        _context.SaveChanges();
        return NoContent();

    }

}