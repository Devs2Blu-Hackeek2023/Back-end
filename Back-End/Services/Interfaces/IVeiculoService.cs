using Back_End.DTOs;
using Back_End.Model;

namespace Back_End.Services.Interfaces
{
	public interface IVeiculoService
	{
		Task<VeiculoModel> GetVeiculoById(int id);
		Task<VeiculoModel> GetVeiculoByPlaca(string placa);
		Task<List<VeiculoModel>> GetAllVeiculos();
		Task CreateVeiculo(VeiculoPostDTO request);
		Task DeleteVeiculo(int id);
		Task<double> GetEmissaoDiaVeiculo(int id, DateTime data);
		Task UpdateVeiculo(int id, VeiculoPutDTO request);
	}
}
