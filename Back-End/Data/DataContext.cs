using Back_End.Model;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<VeiculoModel> Veiculos { get; set; }
        public DbSet<EmissaoModel> Emissoes { get; set; }
        public DbSet<ProprietarioModel> Proprietarios { get; set; }
        public DbSet<RuaModel> Ruas { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VeiculoModel>()
                .HasOne(v => v.Proprietario)
                .WithOne()
                .HasForeignKey<VeiculoModel>(v => v.ProprietarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmissaoModel>()
                .HasOne(e => e.Veiculo)
                .WithOne()
                .HasForeignKey<EmissaoModel>(e => e.VeiculoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmissaoModel>()
                .HasOne(e => e.Rua)
                .WithOne()
                .HasForeignKey<EmissaoModel>(e => e.RuaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProprietarioModel>()
                .HasOne(p => p.Usuario)
                .WithOne()
                .HasForeignKey<ProprietarioModel>(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
