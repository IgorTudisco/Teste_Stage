﻿using System.ComponentModel.DataAnnotations;

namespace Teste_Stage.Data.Dtos.EnderecoDtos;


public class CreateEnderecoDto
{

    public string Logradouro { get; set; }

    public string Numero { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string UF { get; set; }

    public CreateEnderecoDto()
    {
    }

}
