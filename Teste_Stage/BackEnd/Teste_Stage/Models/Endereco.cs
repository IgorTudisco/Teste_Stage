using System.ComponentModel.DataAnnotations;

namespace Teste_Stage.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [MaxLength(50, ErrorMessage = "O tamanho da numero não pode passar de 1 caracteres")]
    public string Logradouro { get; set; }

    [MaxLength(10, ErrorMessage = "O tamanho da numero não pode passar de 1 caracteres")]
    public string Numero { get; set; }

    [MaxLength(50, ErrorMessage = "O tamanho da cidade não pode passar de 1 caracteres")]
    public string Cidade { get; set; }

    [MaxLength(50, ErrorMessage = "O tamanho da estado não pode passar de 1 caracteres")]
    public string Estado { get; set; }

    [MaxLength(2, ErrorMessage = "O tamanho da UF não pode passar de 1 caracteres")]
    public string UF { get; set; }

    // Relacionamento com Candidato
    public virtual Candidato Candidato { get; set; }

    public Endereco()
    {
    }

}
