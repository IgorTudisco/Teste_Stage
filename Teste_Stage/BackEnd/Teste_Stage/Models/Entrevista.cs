using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Teste_Stage.Models;

public class Entrevista
{
    [Key]
    [Required(ErrorMessage = "Campo id é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo cargo é obrigatório")]
    public string Cargo { get; set; }

    [Required(ErrorMessage = "Campo fitCultral é obrigatório")]
    public string FitCultral { get; set; }

    [Required(ErrorMessage = "Campo testeFeito é obrigatório")]
    public Boolean TesteFeito { get; set; }

    [Required(ErrorMessage = "Campo pontuacaoTest é obrigatório")]
    [Range(0.01, 100.00, ErrorMessage = "O campo pontuacaoTest deve estar entre 0,01 e 100,00")]
    public float PontuacaoTest { get; set; }

    // Relacionamento com Candidato
    [JsonIgnore]
    public virtual ICollection<Candidato> Candidato { get; set; }

    public Entrevista()
    {
    }

}
