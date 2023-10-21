using Back_End.Model;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Data
{
    public class DataContext : DbContext
    {// public DbSet<AlienModel> Aliens { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VeiculoModel> Veiculos { get; set; }
        public DbSet<EmissaoModel> Emissoes { get; set; }   
        public DbSet<ProprietarioModel> Proprietarios { get; set;}
        public DbSet<RuaModel> Ruas { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}
