using System.ComponentModel.DataAnnotations;

namespace Teste_Stage.Models;

public class Entrevista
{
    [Key]
    [Required(ErrorMessage = "Campo id é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo candidato é obrigatório")]
    public int CandidatoId { get; set; }

    [Required(ErrorMessage = "Campo cargo é obrigatório")]
    public string Cargo { get; set; }

    [Required(ErrorMessage = "Campo idade é obrigatório")]
    [Range(0.01, 100.00, ErrorMessage = "O campo idade deve estar entre 0,01 e 1.000.000,00")]
    public int Idade { get; set; }

    [Required(ErrorMessage = "Campo fitCultral é obrigatório")]
    public string FitCultral { get; set; }

    [Required(ErrorMessage = "Campo testeFeito é obrigatório")]
    public Boolean TesteFeito { get; set; }

    [Required(ErrorMessage = "Campo pontuacaoTest é obrigatório")]
    [Range(0.01, 100.00, ErrorMessage = "O campo pontuacaoTest deve estar entre 0,01 e 100,00")]
    public float PontuacaoTest { get; set; }

    public Entrevista()
    {
    }

}
