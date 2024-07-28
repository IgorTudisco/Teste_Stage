using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Teste_Stage.Models;

public class Candidato
{
    [Key]
    [Required(ErrorMessage = "Campo id é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo name é obrigatório")]
    public String Name { get; set; }

    [Required(ErrorMessage = "Campo genero é obrigatório")]
    [MaxLength(1, ErrorMessage = "O tamanho da description não pode passar de 1 caracteres")]
    public String Genero { get; set; }

    [Required(ErrorMessage = "Campo idade é obrigatório")]
    [Range(0.01, 100.00, ErrorMessage = "O campo idade deve estar entre 0,01 e 1.000.000,00")]
    public int Idade { get; set; }

    [Required(ErrorMessage = "Campo numeroContato é obrigatório")]
    public String NumeroContato { get; set; }

    [Required(ErrorMessage = "Campo email é obrigatório")]
    public String Email { get; set; }

    [Required(ErrorMessage = "Campo description é obrigatório")]
    [MaxLength(250, ErrorMessage = "O tamanho da description não pode passar de 250 caracteres")]
    public string descricao { get; set; }

    // Relacionamento com Entrevista
    public int? EntrevistaId { get; set; }

    [JsonIgnore]
    public virtual Entrevista Entrevista { get; set; }

    // Relacionamento com Endereço
    public int? EnderecoId { get; set; }

    public virtual Endereco Endereco { get; set; }

    public Candidato()
    {
    }

}
