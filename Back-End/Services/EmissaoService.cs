using Back_End.Model;
using Back_End.Services.Interfaces;

namespace Back_End.Services
{
    public class EmissaoService : IEmissaoService
    {
        public Task CalculoEmissao(EmissaoModel emissaoModel)
        {
            throw new NotImplementedException();
        }

        public Task CreateEmissao(EmissaoModel request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmissao(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmissaoModel>> GetAllEmissao()
        {
            throw new NotImplementedException();
        }

        public Task<EmissaoModel> GetEmissaoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetEmissaoTotal()
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmissao(int id, EmissaoModel request)
        {
            throw new NotImplementedException();
        }
    }
}
