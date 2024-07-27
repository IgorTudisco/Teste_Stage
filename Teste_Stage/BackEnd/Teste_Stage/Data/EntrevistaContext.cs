using Microsoft.EntityFrameworkCore;
using Teste_Stage.Models;

namespace Teste_Stage.Data;

public class EntrevistaContext : DbContext
{
    public EntrevistaContext(DbContextOptions<EntrevistaContext> opts) : base(opts)
    {

    }

    public DbSet<Entrevista> Entrevistas { get; set; }

}
