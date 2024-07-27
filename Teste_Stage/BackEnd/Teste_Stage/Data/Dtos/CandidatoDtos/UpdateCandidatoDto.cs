﻿namespace Teste_Stage.Data.Dtos.CandidatoDtos;

public class UpdateCandidatoDto
{
    private string name;

    private string genero;

    private string numeroContato;

    private string email;

    private string descricao;

    private int enderecoId;

    public UpdateCandidatoDto()
    {
    }

    public string Name { get => name; set => name = value; }
    public string Genero { get => genero; set => genero = value; }
    public string NumeroContato { get => numeroContato; set => numeroContato = value; }
    public string Email { get => email; set => email = value; }
    public string Descricao { get => descricao; set => descricao = value; }
    public int EnderecoId { get => enderecoId; set => enderecoId = value; }
}