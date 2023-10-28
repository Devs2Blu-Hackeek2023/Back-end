using Back_End.DTOs;
using Back_End.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;

		public UsuarioController(IUsuarioService usuarioService) { _usuarioService = usuarioService; }

		[HttpPost]
		public async Task<IActionResult> RegistrarUsuario(UsuarioDTO request)
		{
			try
			{
				await _usuarioService.RegistrarUsuario(request);
				
				return Ok("Usuário criado com sucesso.");
			}
			catch (Exception ex) { return BadRequest(ex.Message); }
		}

		[HttpPost("Id")]
		public async Task<ActionResult> RedefinedPassword(int Id, string password, string newPassword, string confirmationPassword)
		{
			try
			{
				await _usuarioService.UpdateSenha(Id, password, newPassword, confirmationPassword);

				return Ok("Senha redefinida com sucesso.");
			}
			catch (Exception ex) { return BadRequest(ex.Message); }
		}
	}
}
