using Back_End.Model;

namespace Back_End.Services.Interfaces
{
    public interface IRuaService
    {
        Task<RuaModel> GetRuaById(int Id);
        Task<List<RuaModel>> GetAllRuas();
        Task CreateRua(RuaModel request);
        Task UpdateRua(int Id, RuaModel request);
        Task<double> GetEmissaoMesRua(int Id);
        Task<double> GetEmissaoAnualRua(int Id);
        Task<double> GetEmissaoTotalRua(int Id);
    }
}
