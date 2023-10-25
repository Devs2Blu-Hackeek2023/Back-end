using Back_End.Model;

namespace Back_End.Services.Camera
{
	public interface ICameraService
	{
		Task<RuaModel?> SortearRuaAsync();
		Task<VeiculoModel?> SortearVeiculoAsync();
		int SetTempo(int minSecs, int maxSecs);
	}
}
