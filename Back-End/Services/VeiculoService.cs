using Back_End.Model;
using Back_End.Services.Interfaces;

namespace Back_End.Services
{
    public class VeiculoService : IVeiculoService
    {
        public Task CreateVeiculo(VeiculoModel request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVeiculo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VeiculoModel>> GetAllVeiculos()
        {
            throw new NotImplementedException();
        }

        public Task<double> GetEmissaoAnualVeiculo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetEmissaoMesVeiculo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetEmissaoTotalVeiculo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VeiculoModel> GetVeiculoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VeiculoModel> GetVeiculoByPlaca(string placa)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVeiculo(int id, VeiculoModel request)
        {
            throw new NotImplementedException();
        }
    }
}
