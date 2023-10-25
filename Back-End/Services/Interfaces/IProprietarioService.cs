using Back_End.DTOs;
using Back_End.Model;

namespace Back_End.Services.Interfaces
{
    public interface IProprietarioService
    {
        Task<ProprietarioModel> GetProprietarioById(int Id);
        Task<List<ProprietarioModel>> GetAllProprietarios();
        Task CreateProprietario(ProprietarioDTO request);
        Task DeleteProprietario(int Id);
        Task UpdateProprietario(int Id, ProprietarioModel request);
        Task<List<VeiculoModel>> GetVeiculosByProprietario(int Id);
    }
}
