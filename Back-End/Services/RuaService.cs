using Back_End.Data;
using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ViaCep;

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
            _dataContext.Ruas.Add(request);
            await _dataContext.SaveChangesAsync();
        }


        public async Task<List<RuaModel>> GetAllRuas()
        {
            return await _dataContext.Ruas.ToListAsync() ?? throw new ArgumentNullException("Rua não encontrada! 404");
        }

        public async Task<double> GetEmissaoAnualRua(int Id)
        {
            var emissoes = await _dataContext.Emissoes
                .Where(r => r.RuaId == Id && r.DataInicio.Year == DateTime.Now.Year)
                .Select(e => e.CO2)
                .SumAsync() ?? throw new ArgumentNullException("Não tem emissões desse ano! 404");

            return emissoes;
        }

        public async Task<double> GetEmissaoMesRua(int Id)
        {
            var emissoes = await _dataContext.Emissoes
                 .Where(r => r.RuaId == Id && r.DataInicio.Month == DateTime.Now.Month)
                 .Select(e => e.CO2)
                 .SumAsync() ?? throw new ArgumentNullException("Não tem emissões desse mês! 404");

            return emissoes;
        }

        public async Task<double> GetEmissaoTotalRua(int Id)
        {
            return  _dataContext.Emissoes.Where(r => r.RuaId == Id).Select(e => e.CO2).Sum() ?? throw new Exception("Não há emissões nessa rua! 404");
        }

        public async Task<RuaGetDTO> GetRuaByCEP(string Cep)
        {
            var result = new ViaCepClient().Search(Cep);
            var rua = await _dataContext.Ruas.FirstOrDefaultAsync(c => c.CEP == Cep) ?? throw new Exception("Cep não encontrado");
            RuaGetDTO resposta = new RuaGetDTO()
            {
                cep = Cep,
                rua = result.Street,
                bairro = result.Neighborhood,
                cidade = result.City,
                uf = result.StateInitials,
                km = rua.Comprimento
            };
            return resposta;
        }

        public async Task<RuaModel> GetRuaById(int Id)
        {
            return await _dataContext.Ruas.FirstAsync(r => r.Id == Id) ?? throw new ArgumentNullException("Rua não encontrada! 404");
        }

        public async Task UpdateRua(int Id, RuaModel request)
        {
            var ruaModel = new RuaModel()
            {
                CEP = request.CEP,
                Comprimento = request.Comprimento,
            };

            _dataContext.Ruas.Update(ruaModel);
            await _dataContext.SaveChangesAsync();
        }
    }
}
