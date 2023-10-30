using Back_End.DTOs;
using Back_End.Model;

namespace Back_End.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task<VeiculoGetDTO> GetVeiculoById(int id);
        Task<VeiculoGetDTO> GetVeiculoByPlaca(string placa);
        Task<List<VeiculoGetDTO>> GetVeiculoByProprietarioId(int id);
        Task<List<VeiculoGetDTO>> GetAllVeiculos();
        Task CreateVeiculo(VeiculoPostDTO request);
        Task DeleteVeiculo(int id);
        Task<double> GetEmissaoDiaVeiculo(int id, int data, int mes, int ano);
        Task UpdateVeiculo(int id, VeiculoPutDTO request);
        public double? GetMediaGeralDeEmissoesByCategoria(string categoria);
        public List<double?> GetEmissoesUltimos6MesesByVeiculoId(int IdCarro);

    }
}
