namespace Teste_Stage.Data.Dtos.EnderecoDtos;

public class ReadEnderecoDto
{
    private string logradouro;

    private string numero;

    private string cidade;

    private string estado;

    private string uf;

    public ReadEnderecoDto()
    {
    }

    public string Logradouro { get => logradouro; set => logradouro = value; }
    public string Numero { get => numero; set => numero = value; }
    public string Cidade { get => cidade; set => cidade = value; }
    public string Estado { get => estado; set => estado = value; }
    public string Uf { get => uf; set => uf = value; }
}
