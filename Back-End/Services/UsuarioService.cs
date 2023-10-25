using Back_End.Data;
using Back_End.Model;
using Back_End.Services.Interfaces;

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
            await _dataContext.Usuarios.AddAsync(model);
            await _dataContext.SaveChangesAsync();
        }

        public Task UpdateSenha(int id, string request)
        {
            throw new NotImplementedException();
        }
    }
}
