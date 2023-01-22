using Microsoft.EntityFrameworkCore;
using RestApi.Entities.Profissoes;
using RestApi.Entities.Usuarios;

namespace RestApi.Model.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Profissao> Profissoes { get; set; }
    }
}
