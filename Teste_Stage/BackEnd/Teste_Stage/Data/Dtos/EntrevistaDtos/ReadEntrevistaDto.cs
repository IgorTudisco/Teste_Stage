﻿using System.ComponentModel.DataAnnotations;
using Teste_Stage.Models;

namespace Teste_Stage.Data.Dtos.EntrevistaDtos;

public class ReadEntrevistaDto
{
    public Candidato Candidato { get; set; }

    public string Cargo { get; set; }

    public int Idade { get; set; }

    public string FitCultral { get; set; }

    public bool TesteFeito { get; set; }

    public float PontuacaoTest { get; set; }

    public ReadEntrevistaDto()
    {
    }

}
