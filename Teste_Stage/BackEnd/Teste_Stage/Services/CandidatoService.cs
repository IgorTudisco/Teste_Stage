using AutoMapper;
using Castle.Core.Internal;
using Teste_Stage.Data;
using Teste_Stage.Data.Dtos.CandidatoDtos;
using Teste_Stage.Models;

namespace Teste_Stage.Services;

/// <summary>
/// Serviço responsável por gerenciar as operações relacionadas a candidatos.
/// </summary>
public class CandidatoService
{
    private CandidatoContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Inicializa uma nova instância do serviço de candidatos.
    /// </summary>
    /// <param name="context">Contexto do banco de dados.</param>
    /// <param name="mapper">Mapper para conversão de objetos DTO.</param>
    public CandidatoService(CandidatoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Verifica se um endereço ID já está associado a um candidato existente.
    /// </summary>
    /// <param name="candidatoDto">Objeto DTO de criação de candidato.</param>
    /// <returns>Retorna "ok" se o endereço ID não estiver duplicado, caso contrário, retorna null.</returns>
    public string? VerificaEnderecoIdDuplicado(CreateCandidatoDto candidatoDto)
    {
        // Verifica se tem algum id de "enderecoId" já cadastrado para evitar a duplicidade.
        var candidatoEndereco = _context.Candidatos.FirstOrDefault(candidato => candidato.EnderecoId == candidatoDto.EnderecoId);
        if (candidatoEndereco != null)
        {
            return null;
        }
        else
        {
            return "ok";
        }
    }

    /// <summary>
    /// Verifica se os IDs fornecidos no DTO não são nulos.
    /// </summary>
    /// <param name="candidatoDto">Objeto DTO de criação de candidato.</param>
    /// <returns>Retorna "ok" se os IDs não forem nulos, caso contrário, retorna null.</returns>
    public string? VerificaIdNullo(CreateCandidatoDto candidatoDto)
    {
        // Achando o id de "enderecoId" para que ele não atualize como nulo.
        var endereco = _context.Enderecos.Where(endereco => endereco.Id == candidatoDto.EnderecoId).ToList();
        if (endereco.IsNullOrEmpty()) return null;

        // Achando o id de "entrevistaId" para que não salve como nulo.
        var entrevista = _context.Entrevistas.Where(entrevista => entrevista.Id == candidatoDto.EntrevistaId).ToList();
        if (entrevista.IsNullOrEmpty()) return null;

        return "ok";
    }

    /// <summary>
    /// Cadastra um novo candidato no banco de dados.
    /// </summary>
    /// <param name="candidatoDto">Objeto DTO de criação de candidato.</param>
    /// <returns>Retorna o objeto candidato criado.</returns>
    public Candidato CadastrarCandidatoService(CreateCandidatoDto candidatoDto)
    {

        Candidato candidato = _mapper.Map<Candidato>(candidatoDto);
        _context.Candidatos.Add(candidato);
        _context.SaveChanges();
        return candidato;

    }

    /// <summary>
    /// Recupera uma lista de candidatos com base nos parâmetros de paginação.
    /// </summary>
    /// <param name="skip">Número de elementos a pular.</param>
    /// <param name="take">Número de elementos a retornar.</param>
    /// <returns>Retorna uma lista de candidatos.</returns>
    public IEnumerable<ReadCandidatoDto> RecuperaCandidatosService(int skip = 0, int take = 5)
    {
        return _mapper.Map<List<ReadCandidatoDto>>(_context.Candidatos.ToList().Skip(skip).Take(take));
    }

    /// <summary>
    /// Encontra um candidato específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do candidato a ser encontrado.</param>
    /// <returns>Retorna o objeto DTO do candidato encontrado ou null se não encontrado.</returns>
    public ReadCandidatoDto? AchaCandidatoPorIdService(int id)
    {
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
        if (candidato == null)
            return null;
        var candidatoDto = _mapper.Map<ReadCandidatoDto>(candidato);
        return candidatoDto;
    }

    /// <summary>
    /// Atualiza as informações de um candidato específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do candidato a ser atualizado.</param>
    /// <param name="candidatoDto">Objeto DTO de atualização de candidato.</param>
    /// <returns>Retorna 0 se a atualização for bem-sucedida, 1 se o endereço ID for inválido, e null se o candidato não for encontrado.</returns>
    public int? AtualizaCandidatoService(int id, UpdateCandidatoDto candidatoDto)
    {
        // Verifica se tem um candidato para ser atualizado com base no id informado.
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
        if (candidato == null) return null;

        if (candidato.EnderecoId != candidatoDto.EnderecoId)
        {
            // Verifica se tem algum id de "enderecoId" já cadastrado para evitar a duplicidade.
            var candidatoEndereco = _context.Candidatos.FirstOrDefault(candidato => candidato.EnderecoId == candidatoDto.EnderecoId);
            if (candidatoEndereco != null)
            {
                return 1;
            }
            else
            {
                // Achando o id de "enderecoId" para que ele não atualize como nulo.
                var endereco = _context.Enderecos.Where(endereco => endereco.Id == candidatoDto.EnderecoId).ToList();
                if (endereco.IsNullOrEmpty()) return null;
            }
        }

        // Achando o id de "entrevistaId" para que ele não atualize como nulo.
        var entrevista = _context.Entrevistas.Where(entrevista => entrevista.Id == candidatoDto.EntrevistaId).ToList();
        if (entrevista.IsNullOrEmpty()) return null;

        _mapper.Map(candidatoDto, candidato);
        _context.SaveChanges();
        return 0;
    }

    /// <summary>
    /// Deleta um candidato específico com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do candidato a ser deletado.</param>
    /// <returns>Retorna o objeto candidato deletado ou null se não encontrado.</returns>
    public Candidato? DeleteCandidatoService(int id)
    {
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
        if (candidato == null) return null;
        _context.Remove(candidato);
        _context.SaveChanges();
        return candidato;
    }

}
