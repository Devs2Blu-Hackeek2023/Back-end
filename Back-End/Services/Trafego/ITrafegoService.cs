using Back_End.Model;

namespace Back_End.Services.Trafego
{
	public interface ITrafegoService
	{
		Task<RuaModel?> SortearRuaAsync();
		Task<VeiculoModel?> SortearVeiculoAsync();
		Task IniciarTrafego();
	}
}
