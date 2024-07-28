using AutoMapper;
using Teste_Stage.Data.Dtos.EntrevistaDtos;
using Teste_Stage.Data;
using Teste_Stage.Models;

namespace Teste_Stage.Services;

/// <summary>
/// Classe de serviço para gerenciar operações relacionadas a Entrevistas.
/// </summary>
public class EntrevistaService
{
    private CandidatoContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Construtor da classe EntrevistaService.
    /// </summary>
    /// <param name="context">Contexto do banco de dados CandidatoContext.</param>
    /// <param name="mapper">Instância do IMapper para mapeamento de objetos.</param>
    public EntrevistaService(CandidatoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Cadastra uma nova entrevista no banco de dados.
    /// </summary>
    /// <param name="entrevistaDto">Objeto com os campos necessários para criação de uma entrevista.</param>
    /// <returns>O objeto Entrevista cadastrado.</returns>
    public Entrevista CadastrarEntrevistaService(CreateEntrevistaDto entrevistaDto)
    {
        Entrevista entrevista = _mapper.Map<Entrevista>(entrevistaDto);
        _context.Entrevistas.Add(entrevista);
        _context.SaveChanges();
        return entrevista;
    }

    /// <summary>
    /// Recupera uma lista de entrevistas com paginação.
    /// </summary>
    /// <param name="skip">Número de elementos a pular.</param>
    /// <param name="take">Número de elementos a retornar.</param>
    /// <returns>IEnumerable contendo as entrevistas recuperadas.</returns>
    public IEnumerable<ReadEntrevistaDto> RecuperaEntrevistasService(int skip = 0, int take = 5)
    {
        return _mapper.Map<List<ReadEntrevistaDto>>(_context.Entrevistas.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    /// Recupera uma entrevista específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID da entrevista a ser encontrada.</param>
    /// <returns>Objeto ReadEntrevistaDto contendo os dados da entrevista encontrada ou null se não for encontrada.</returns>
    public ReadEntrevistaDto? AchaEntrevistaPorIdService(int id)
    {
        var entrevista = _context.Entrevistas.FirstOrDefault(entrevista => entrevista.Id == id);
        if (entrevista == null)
            return null;
        var entrevistaDto = _mapper.Map<ReadEntrevistaDto>(entrevista);
        return entrevistaDto;
    }

    /// <summary>
    /// Atualiza uma entrevista específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID da entrevista a ser atualizada.</param>
    /// <param name="entrevistaDto">Objeto contendo os dados atualizados da entrevista.</param>
    /// <returns>O objeto Entrevista atualizado ou null se não for encontrada.</returns>
    public Entrevista? AtualizaEntrevistaService(int id, UpdateEntrevistaDto entrevistaDto)
    {
        var entrevista = _context.Entrevistas.FirstOrDefault(entrevista => entrevista.Id == id);
        if (entrevista == null) return null;
        _mapper.Map(entrevistaDto, entrevista);
        _context.SaveChanges();
        return entrevista;
    }

    /// <summary>
    /// Deleta uma entrevista específica com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID da entrevista a ser deletada.</param>
    /// <returns>O objeto Entrevista deletado ou null se não for encontrada.</returns>
    public Entrevista? DeleteEntrevistaService(int id)
    {
        var entrevista = _context.Entrevistas.FirstOrDefault(entrevista => entrevista.Id == id);
        if (entrevista == null) return null;

        // Desassocia os candidatos da entrevista
        var candidatos = _context.Candidatos.Where(candidatos => candidatos.EntrevistaId == id).ToList();
        foreach (Candidato candidato in candidatos)
            candidato.EntrevistaId = null;
        _context.SaveChanges();

        _context.Entrevistas.Remove(entrevista);
        _context.SaveChanges();
        return entrevista;
    }


}
