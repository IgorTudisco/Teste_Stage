using System.ComponentModel.DataAnnotations;

namespace Teste_Stage.Models;

public class Endereco
{
    [Key]
    [Required]
    private int id;

    [MaxLength(50, ErrorMessage = "O tamanho da numero não pode passar de 1 caracteres")]
    private string logradouro;

    [MaxLength(10, ErrorMessage = "O tamanho da numero não pode passar de 1 caracteres")]
    private string numero;

    [MaxLength(50, ErrorMessage = "O tamanho da cidade não pode passar de 1 caracteres")]
    private string cidade;

    [MaxLength(50, ErrorMessage = "O tamanho da estado não pode passar de 1 caracteres")]
    private string estado;

    [MaxLength(2, ErrorMessage = "O tamanho da UF não pode passar de 1 caracteres")]
    private string uf;

    public virtual Candidato Candidato { get; set; }

    public Endereco()
    {
    }

    public int Id { get => id; set => id = value; }
    public string Logradouro { get => logradouro; set => logradouro = value; }
    public string Numero { get => numero; set => numero = value; }
    public string Cidade { get => cidade; set => cidade = value; }
    public string Estado { get => estado; set => estado = value; }
    public string Uf { get => uf; set => uf = value; }


}
