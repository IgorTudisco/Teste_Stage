using AutoMapper;
using Teste_Stage.Data;
using Teste_Stage.Data.Dtos.EnderecoDtos;
using Teste_Stage.Data.Dtos.EntrevistaDtos;
using Teste_Stage.Models;

namespace Teste_Stage.Services;

/// <summary>
/// Classe de serviço para gerenciar operações relacionadas a Endereços.
/// </summary>
public class EnderecoService
{
    private CandidatoContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Construtor da classe EnderecoService.
    /// </summary>
    /// <param name="context">Contexto do banco de dados CandidatoContext.</param>
    /// <param name="mapper">Instância do IMapper para mapeamento de objetos.</param>
    public EnderecoService(CandidatoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Cadastra um novo endereço no banco de dados.
    /// </summary>
    /// <param name="enderecoDto">Objeto com os campos necessários para criação de um endereço.</param>
    /// <returns>O objeto Endereco cadastrado.</returns>
    public Endereco CadastrarEnderecoService(CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return endereco;
    }

    /// <summary>
    /// Recupera uma lista de endereços com paginação.
    /// </summary>
    /// <param name="skip">Número de elementos a pular na lista de endereços.</param>
    /// <param name="take">Número de elementos a serem retornados na resposta.</param>
    /// <returns>Uma lista de `ReadEnderecoDto` contendo os endereços recuperados.</returns>
    public IEnumerable<ReadEnderecoDto> RecuperaEnderecosService(int skip = 0, int take = 5)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    /// Recupera um endereço específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do endereço a ser encontrado.</param>
    /// <returns>Objeto ReadEnderecoDto contendo os dados do endereço encontrado ou null se não for encontrado.</returns>
    public ReadEnderecoDto? AchaEnderecoPorIdService(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
            return null;
        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return enderecoDto;
    }

    /// <summary>
    /// Atualiza um endereço específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do endereço a ser atualizado.</param>
    /// <param name="enderecoDto">Objeto contendo os dados atualizados do endereço.</param>
    /// <returns>O objeto Endereco atualizado ou null se não for encontrado.</returns>
    public Endereco? AtualizaEnderecoService(int id, UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return null;
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return endereco;
    }

    /// <summary>
    /// Deleta um endereço específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do endereço a ser deletado.</param>
    /// <returns>O objeto Endereco deletado ou null se não for encontrado.</returns>
    public Endereco? DeleteEnderecoService(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return null;

        // Desassocia os candidatos do endereço
        var candidatos = _context.Candidatos.Where(candidatos => candidatos.EnderecoId == id).ToList();
        foreach (var candidato in candidatos)
            candidato.EnderecoId = null;
        _context.SaveChanges();

        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
        return endereco;
    }

}
