using Back_End.DTOs;
using Back_End.Model;

namespace Back_End.Services.Interfaces
{
    public interface IRuaService
    {
        Task<RuaGetDTO> GetRuaById(int Id);
        RuaGetDTO GetRuaByCEP(string Cep);
        Task<List<RuaGetDTO>> GetAllRuas();
        Task CreateRua(RuaModel request);
        Task UpdateRua(int Id, RuaModel request);
        Task<double> GetEmissaoMesRua(int Id);
        Task<double> GetEmissaoAnualRua(int Id);
        Task<double> GetEmissaoTotalRua(int Id);

    }
}
