using Back_End.Model;
using Back_End.Services.Interfaces;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuararioService;

        public UsuarioController(IUsuarioService usuararioService)
        {
            _usuararioService = usuararioService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UsuarioModel request)
        {
            try
            {
                request.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);
                await _usuararioService.CreateUsuario(request);
                return Ok("Usuário criado");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

         
         
    }
}
