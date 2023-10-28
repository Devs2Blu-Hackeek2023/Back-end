using Back_End.DTOs;

namespace Back_End.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task RegistrarUsuario(UsuarioDTO usuarioDTO);
        Task UpdateSenha(int id, string request, string newSenha, string confirmationSenha);
    }
}
