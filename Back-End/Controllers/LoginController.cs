using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Back_End.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILoginService _loginService;

		public LoginController(ILoginService loginService) { _loginService = loginService; }

		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult<string>> Login(LoginDTO loginDTO)
		{
			try
			{
				string token = await _loginService.Login(loginDTO);

				return Ok(token);
			}
			catch (Exception ex) { return BadRequest(ex.Message); }
		}
	}
}
