using Back_End.Model;

namespace Back_End.Services.Camera
{
	public interface ICameraService
	{
		Task<VeiculoModel?> SortearVeiculoAsync();
	}
}
