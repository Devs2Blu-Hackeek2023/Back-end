using Back_End.DTOs;

namespace Back_End.Services.Interfaces
{
	public interface ILoginService
	{
		Task<string> Login(LoginDTO loginDTO);
		string GetUsuarioRole(HttpContext httpContext);
		bool AcessoPermitido(HttpContext httpContext, int id);
	}
}
