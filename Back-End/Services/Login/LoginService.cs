using Back_End.Data;
using Back_End.DTOs;
using Back_End.Model;
using Back_End.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Back_End.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public LoginService(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        private async Task<UsuarioModel?> GetUsuarioRegistrado(LoginDTO loginDTO)
        {
            UsuarioModel? usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == loginDTO.Username);

            if (usuario is null) return null;
            else return usuario;
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            UsuarioModel? usuario = await GetUsuarioRegistrado(loginDTO);

            if (usuario is null) throw new Exception("Usuário inválido.");
            else
            {
                if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, usuario.PasswordHash)) throw new Exception("Senha inválida.");
                else
                {
                    string token = GerarToken(usuario);

                    return token;
                }
            }
        }

        private static UsuarioDTO? GetUsuarioAtual(HttpContext httpContext)
        {
            if (httpContext.User.Identity is not ClaimsIdentity claimsIdentity) return null;
            else
            {
                Claim? nome = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                Claim? username = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName);
                Claim? cargo = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                if (nome is null || username is null || cargo is null) return null;
                else
                {
                    return new UsuarioDTO
                    {
                        Nome = nome.Value,
                        Username = username.Value,
                        Cargo = cargo.Value
                    };
                }
            }
        }

        public string GetUsuarioRole(HttpContext httpContext)
        {
            UsuarioDTO? usuario = GetUsuarioAtual(httpContext);

            if (usuario is null) return "";
            else return usuario.Cargo;
        }

        public bool AcessoPermitido(HttpContext httpContext, int id)
        {
            UsuarioDTO? usuario = GetUsuarioAtual(httpContext);

            if (usuario is null) return false;
            else return usuario.Cargo == UsuarioRolesModel.Admin || usuario.Id == id;
        }

        private string GerarToken(UsuarioModel usuario)
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.GivenName, usuario.Username),
                new Claim(ClaimTypes.Role, usuario.Cargo)
            };

            JwtSecurityToken token = new(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    signingCredentials: creds,
                    expires: DateTime.Now.AddDays(5)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
