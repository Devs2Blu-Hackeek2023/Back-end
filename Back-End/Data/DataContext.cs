using Back_End.Model;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options) { }

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
				.WithMany()
				.HasForeignKey(v => v.ProprietarioId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<EmissaoModel>()
				.HasOne(e => e.Veiculo)
				.WithMany()
				.HasForeignKey(e => e.VeiculoId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<EmissaoModel>()
				.HasOne(e => e.Rua)
				.WithMany()
				.HasForeignKey(e => e.RuaId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ProprietarioModel>()
				.HasOne(p => p.Usuario)
				.WithMany()
				.HasForeignKey(p => p.UsuarioId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
