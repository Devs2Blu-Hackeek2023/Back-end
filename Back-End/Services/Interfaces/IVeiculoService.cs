using Back_End.Model;

namespace Back_End.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task<VeiculoModel> GetVeiculoById(int id);
        Task<VeiculoModel> GetVeiculoByPlaca(string placa);
        Task<List<VeiculoModel>> GetAllVeiculos();
        Task CreateVeiculo(VeiculoModel request);
        Task DeleteVeiculo(int id);
        Task<double> GetEmissaoMesVeiculo(int id);
        Task<double> GetEmissaoTotalVeiculo(int id);
        Task<double> GetEmissaoAnualVeiculo(int id);
        Task UpdateVeiculo(int id, VeiculoModel request);
    }
}
