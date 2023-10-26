using Back_End.DTOs;
using Back_End.Model;

namespace Back_End.Services.Interfaces
{
	public interface IEmissaoService
	{
		Task<EmissaoModel> GetEmissaoById(int id);
		Task<List<EmissaoModel>> GetAllEmissao();
		Task<EmissaoModel> CreateEmissao(EmissaoPostDTO request);
		Task DeleteEmissao(int id);
		Task UpdateEmissao(int id, EmissaoPutDTO request);
		double CalculoEmissao(int id);
		double? GetEmissaoTotal();
		double? GetEmissaoDeTalAno(int ano);
		double? GetEmissaoDeTalMes(int mes, int ano);
		double? GetEmissaoDeTalDia(int dia, int mes, int ano);
		double? GetEmissaoDoUltimoAno();
		double? GetEmissaoDoUltimoDia();
		double? GetEmissaoDoUltimoMes();
		Task Emissao();
	}
}
