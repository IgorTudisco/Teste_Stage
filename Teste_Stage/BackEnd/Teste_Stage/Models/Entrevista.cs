using System.ComponentModel.DataAnnotations;

namespace Teste_Stage.Models;

public class Entrevista
{
    [Key]
    [Required(ErrorMessage = "Campo id é obrigatório")]
    private int id;

    [Required(ErrorMessage = "Campo candidato é obrigatório")]
    private Candidato candidato;

    [Required(ErrorMessage = "Campo cargo é obrigatório")]
    private String cargo;

    [Required(ErrorMessage = "Campo idade é obrigatório")]
    [Range(0.01, 100.00, ErrorMessage = "O campo idade deve estar entre 0,01 e 1.000.000,00")]
    private int idade;

    [Required(ErrorMessage = "Campo fitCultral é obrigatório")]
    private String fitCultral;

    [Required(ErrorMessage = "Campo testeFeito é obrigatório")]
    private Boolean testeFeito;

    [Required(ErrorMessage = "Campo pontuacaoTest é obrigatório")]
    [Range(0.01, 100.00, ErrorMessage = "O campo pontuacaoTest deve estar entre 0,01 e 100,00")]
    private float pontuacaoTest;

    public Entrevista()
    {
    }

    public int Id { get => id; set => id = value; }
    public Candidato Candidato { get => candidato; set => candidato = value; }
    public string Cargo { get => cargo; set => cargo = value; }
    public int Idade { get => idade; set => idade = value; }
    public string FitCultral { get => fitCultral; set => fitCultral = value; }
    public bool TesteFeito { get => testeFeito; set => testeFeito = value; }
    public float PontuacaoTest { get => pontuacaoTest; set => pontuacaoTest = value; }
}
