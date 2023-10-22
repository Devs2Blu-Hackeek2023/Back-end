using Back_End.Model;
using Back_End.Services.Interfaces;

namespace Back_End.Services
{
    public class ProprietarioService : IProprietarioService
    {
        public Task CreateProprietario(ProprietarioModel request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProprietario(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProprietarioModel>> GetAllProprietarios()
        {
            throw new NotImplementedException();
        }

        public Task<ProprietarioModel> GetProprietarioById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VeiculoModel>> GetVeiculoByProprietario(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProprietario(int Id, ProprietarioModel request)
        {
            throw new NotImplementedException();
        }
    }
}
