using Back_End.DTOs;
using Back_End.Model;

namespace Back_End.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task<VeiculoModel> GetVeiculoById(int id); //ok*
        Task<VeiculoModel> GetVeiculoByPlaca(string placa); //ok*
        Task<List<VeiculoModel>> GetAllVeiculos(); //ok*
        Task CreateVeiculo(VeiculoModel request); //ok*
        Task DeleteVeiculo(int id); //ok*
        Task<double> GetEmissaoDiaVeiculo(int id, DateTime data); //ok*
        Task UpdateVeiculo(int id, VeiculoPutDTO request); //ok*
    }
}
