using System.ComponentModel.DataAnnotations;
using Teste_Stage.Models;

namespace Teste_Stage.Data.Dtos.EntrevistaDtos;

public class ReadEntrevistaDto
{
    private Candidato candidato;

    private string cargo;

    private int idade;

    private string fitCultral;

    private bool testeFeito;

    private float pontuacaoTest;

    private DateTime horaDaConsulta = DateTime.Now;

    public ReadEntrevistaDto()
    {
    }

    public Candidato Candidato { get => candidato; set => candidato = value; }
    public string Cargo { get => cargo; set => cargo = value; }
    public int Idade { get => idade; set => idade = value; }
    public string FitCultral { get => fitCultral; set => fitCultral = value; }
    public bool TesteFeito { get => testeFeito; set => testeFeito = value; }
    public float PontuacaoTest { get => pontuacaoTest; set => pontuacaoTest = value; }
    public DateTime HoraDaConsulta { get => horaDaConsulta; set => horaDaConsulta = value; }
}
