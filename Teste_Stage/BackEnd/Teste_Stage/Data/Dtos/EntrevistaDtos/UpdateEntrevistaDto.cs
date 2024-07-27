﻿using System.ComponentModel.DataAnnotations;
using Teste_Stage.Models;

namespace Teste_Stage.Data.Dtos.EntrevistaDtos;

public class UpdateEntrevistaDto
{
    [Required(ErrorMessage = "Campo candidato é obrigatório")]
    private Candidato candidato;

    [Required(ErrorMessage = "Campo cargo é obrigatório")]
    private string cargo;

    [Required(ErrorMessage = "Campo idade é obrigatório")]
    [Range(0.01, 100.00, ErrorMessage = "O campo idade deve estar entre 0,01 e 1.000.000,00")]
    private int idade;

    [Required(ErrorMessage = "Campo fitCultral é obrigatório")]
    private string fitCultral;

    [Required(ErrorMessage = "Campo testeFeito é obrigatório")]
    private bool testeFeito;

    [Required(ErrorMessage = "Campo pontuacaoTest é obrigatório")]
    [Range(0.01, 100.00, ErrorMessage = "O campo pontuacaoTest deve estar entre 0,01 e 100,00")]
    private float pontuacaoTest;

    public UpdateEntrevistaDto()
    {
    }

    public Candidato Candidato { get => candidato; set => candidato = value; }
    public string Cargo { get => cargo; set => cargo = value; }
    public int Idade { get => idade; set => idade = value; }
    public string FitCultral { get => fitCultral; set => fitCultral = value; }
    public bool TesteFeito { get => testeFeito; set => testeFeito = value; }
    public float PontuacaoTest { get => pontuacaoTest; set => pontuacaoTest = value; }
}