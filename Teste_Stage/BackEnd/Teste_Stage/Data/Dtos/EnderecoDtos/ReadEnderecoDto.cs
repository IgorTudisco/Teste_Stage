namespace Teste_Stage.Data.Dtos.EnderecoDtos;

public class ReadEnderecoDto
{
    public int Id { get; set; }
    public string Logradouro { get; set; }

    public string Numero { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string UF { get; set; }

    public ReadEnderecoDto()
    {
    }

}
