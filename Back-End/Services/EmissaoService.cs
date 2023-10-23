using Back_End.Data;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Services
{
    public class EmissaoService : IEmissaoService
    {
        private readonly DataContext _context;
        public EmissaoService(DataContext context)
        {
            _context = context;
        }
        public Task CalculoEmissao(EmissaoModel emissaoModel)
        {
            throw new NotImplementedException();
        }

        public async Task CreateEmissao(EmissaoModel request) // editar
        {
            await _context.Emissoes.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmissao(int id)
        {
            var request = await _context.Emissoes.FirstOrDefaultAsync(e => e.Id == id) ?? throw new ArgumentNullException("Emissão não encontrada! 404");
            _context.Emissoes.Remove(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmissaoModel>> GetAllEmissao()
        {
            return await _context.Emissoes.ToListAsync() ?? throw new ArgumentNullException("Emissão não encontrada! 404");
        }

        public async Task<EmissaoModel> GetEmissaoById(int id)
        {
            return await _context.Emissoes.FirstOrDefaultAsync(e => e.Id == id) ?? throw new ArgumentNullException("Emissão não encontrada! 404");
        }

        public double? GetEmissaoTotal()
        {
            return _context.Emissoes.Select(e => e.CO2).ToList().Sum();
        }

        public double? GetEmissaoDeTalAno(int ano)
        {
            return _context.Emissoes.Where(e => e.DataInicio.Year == ano).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse ano! 404");
        }

        public double? GetEmissaoDeTalMes(int mes) // checar formato, mudar
        {
            return _context.Emissoes.Where(e => e.DataInicio.Month == mes).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse mês! 404");
        }

        public double? GetEmissaoDeTalDia(int mes) // checar formato
        {
            return _context.Emissoes.Where(e => e.DataInicio.Month == mes).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse mês! 404");
        }

        public double? GetEmissaoDoUltimoAno()
        {
            return _context.Emissoes.Where(e => (DateTime.Now.Year - e.DataInicio.Year) <= 1).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse ano! 404");
        }

        public double? GetEmissaoDoUltimoDia()
        {
            return _context.Emissoes.Where(e => (DateTime.Now.Day - e.DataFim.Value.Day) <= 1).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse dia! 404");
        }
        
        public double? GetEmissaoDoUltimoMes()
        {
            return _context.Emissoes.Where(e => (DateTime.Now.Month - e.DataFim.Value.Month) <= 1).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse mês! 404");
        }
    

        public async Task UpdateEmissao(int id, EmissaoModel request) //editar
        {
            var model = await _context.Emissoes.FirstOrDefaultAsync(e => e.Id == id) ?? throw new ArgumentNullException("Emissão não encontrada! 404");
            model = request;
            _context.SaveChanges();
        }
    }
}
