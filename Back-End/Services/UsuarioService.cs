using Back_End.Data;
using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;

namespace Back_End.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly DataContext _dataContext;
		private readonly UsuarioModel _usuario = new();

		public UsuarioService(DataContext dataContext) { _dataContext = dataContext; }

		public async Task RegistrarUsuario(UsuarioDTO usuarioDTO)
		{
			_usuario.Nome = usuarioDTO.Nome;
			_usuario.Username = usuarioDTO.Username;
			_usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(usuarioDTO.Password);
			_usuario.Cargo = "usuario";

			await _dataContext.Usuarios.AddAsync(_usuario);
			await _dataContext.SaveChangesAsync();
		}

		public async Task UpdateSenha(int id, string password, string newPassword, string confirmationPassword)
		{
			var user = await _dataContext.Usuarios.FindAsync(id) ?? throw new Exception("Nome de usuário inválido.");

			if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) throw new Exception("Senha inválida.");
			else if (BCrypt.Net.BCrypt.Verify(newPassword, user.PasswordHash)) throw new Exception("Nova senha não pode ser igual à anterior.");
			else
			{
				if (!BCrypt.Net.BCrypt.Verify(confirmationPassword, BCrypt.Net.BCrypt.HashPassword(newPassword))) throw new Exception("Senhas inseridas não correspondem.");
				else
				{
					user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
					await _dataContext.SaveChangesAsync();
				}
			}
		}
	}
}
