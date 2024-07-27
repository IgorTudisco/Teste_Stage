﻿using Microsoft.EntityFrameworkCore;
using Teste_Stage.Models;

namespace Teste_Stage.Data;

public class CandidatoContext : DbContext
{
    public CandidatoContext(DbContextOptions<CandidatoContext> opts) : base(opts)
    {

    }

    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Entrevista> Entrevistas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }


}
