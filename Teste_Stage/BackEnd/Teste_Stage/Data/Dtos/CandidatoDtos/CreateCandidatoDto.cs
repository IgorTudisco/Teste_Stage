using System.ComponentModel.DataAnnotations;

namespace Teste_Stage.Data.Dtos.CandidatoDtos;

public class CreateCandidatoDto
{
    private String name;

    private String genero;

    private String numeroContato;

    private String email;

    private String descricao;

    private int enderecoId;

    public CreateCandidatoDto()
    {
    }

    public string Name { get => name; set => name = value; }
    public string Genero { get => genero; set => genero = value; }
    public string NumeroContato { get => numeroContato; set => numeroContato = value; }
    public string Email { get => email; set => email = value; }
    public string Descricao { get => descricao; set => descricao = value; }
    public int EnderecoId { get => enderecoId; set => enderecoId = value; }
}
