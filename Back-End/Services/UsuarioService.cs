using Back_End.Data;
using Back_End.Model;
using Back_End.Services.Interfaces;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DataContext _dataContext;

        public UsuarioService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateUsuario(UsuarioModel model)
        {
            if (!(_dataContext.Usuarios.FirstOrDefaultAsync(u => u.Username == model.Username) is null)) throw new Exception("Username já está sendo usado, escolha outro.");

            await _dataContext.Usuarios.AddAsync(model);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateSenha(int id, string password, string newPassword, string confirmationPassword)
        {
            var user = await _dataContext.Usuarios.FindAsync(id) ?? throw new Exception("Usuário não encontrado");

            if (!(BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))) throw new Exception("Senha digitada não corresponde com a atual");
            else if (BCrypt.Net.BCrypt.Verify(newPassword, user.PasswordHash)) throw new Exception("Nova senha não pode ser igual a anterior");

            if(!(BCrypt.Net.BCrypt.Verify(confirmationPassword,BCrypt.Net.BCrypt.HashPassword(newPassword))))
            {
                throw new Exception("Senhas inseridas não correspondem");
               
            }
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _dataContext.SaveChangesAsync();
        }
    }
}
