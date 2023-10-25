using Back_End.Data;
using Back_End.Model;
using Back_End.Services.Interfaces;

namespace Back_End.Services
{
    public class RuaService : IRuaService
    {
        private readonly DataContext _dataContext;

        public RuaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateRua(RuaModel request)
        {
            throw new NotImplementedException();
        }


        public Task<List<RuaModel>> GetAllRuas()
        {
            throw new NotImplementedException();
        }

        public Task<double> GetEmissaoAnualRua(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetEmissaoMesRua(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetEmissaoTotalRua(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<RuaModel> GetRuaById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRua(int Id, RuaModel request)
        {
            throw new NotImplementedException();
        }
    }
}
