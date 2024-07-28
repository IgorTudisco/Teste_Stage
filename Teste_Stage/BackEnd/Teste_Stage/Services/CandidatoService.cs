using AutoMapper;
using Castle.Core.Internal;
using Teste_Stage.Data;
using Teste_Stage.Data.Dtos.CandidatoDtos;
using Teste_Stage.Models;

namespace Teste_Stage.Services;

public class CandidatoService
{
    private CandidatoContext _context;
    private IMapper _mapper;

    public CandidatoService(CandidatoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

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

    public Candidato CadastrarCandidatoService(CreateCandidatoDto candidatoDto)
    {

        Candidato candidato = _mapper.Map<Candidato>(candidatoDto);
        _context.Candidatos.Add(candidato);
        _context.SaveChanges();
        return candidato;

    }

    public IEnumerable<ReadCandidatoDto> RecuperaCandidatosService(int skip = 0, int take = 5)
    {
        return _mapper.Map<List<ReadCandidatoDto>>(_context.Candidatos.ToList().Skip(skip).Take(take));
    }

    public ReadCandidatoDto? AchaCandidatoPorIdService(int id)
    {
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
        if (candidato == null)
            return null;
        var candidatoDto = _mapper.Map<ReadCandidatoDto>(candidato);
        return candidatoDto;
    }

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

    public Candidato? DeleteCandidatoService(int id)
    {
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
        if (candidato == null) return null;
        _context.Remove(candidato);
        _context.SaveChanges();
        return candidato;
    }

}
