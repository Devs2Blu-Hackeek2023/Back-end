using Back_End.Data;
using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Camera;
using Back_End.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Services
{
    public class EmissaoService : IEmissaoService
    {
        private readonly DataContext _context;
        private readonly CameraService _camera;

        Random random = new Random(36);

        public EmissaoService(DataContext context)
        {
            _context = context;
        }
        public double CalculoEmissao(int id)
        {
            var emissao =  _context.Emissoes.FirstOrDefault(e => e.Id == id) ?? throw new ArgumentNullException("Emissão não encontrada! 404");
            var veiculo =  _context.Veiculos.FirstOrDefault(v => v.Id == emissao.VeiculoId) ?? throw new ArgumentNullException("Veiculo não encontrado! 404");
            var rua =  _context.Ruas.FirstOrDefault(r => r.Id == emissao.RuaId) ?? throw new ArgumentNullException("Rua não encontrada! 404");
            var tipoCombustivel = veiculo.Combustivel;
            var kmRua = rua.Comprimento;
            var kml = veiculo.KmL;
            double constante = 0;

            if(tipoCombustivel == "Gasolina" || tipoCombustivel == "gasolina") constante = 2.39;
            if (tipoCombustivel == "Diesel" || tipoCombustivel == "diesel") constante = 2.64;
            if (tipoCombustivel == "Gás Natural Veicular" || tipoCombustivel == "Gás" || tipoCombustivel == "GNV" || tipoCombustivel == "gas" || tipoCombustivel == "gás" || tipoCombustivel == "Gas") constante = 1.66;
            if (tipoCombustivel == "Etanol" || tipoCombustivel == "etanol" || tipoCombustivel == "Alcool" || tipoCombustivel == "alcool") constante = 0.504;

            double litros = kmRua / kml;

            double resultado = litros * constante;

            return resultado;
        }

        public async Task Emissao()
        {
            var carro = await _camera.SortearVeiculoAsync();
            var rua =  await _camera.SortearRuaAsync();
            DateTime inicio = DateTime.Now;
            int segundos = random.Next(300, 1200);
            DateTime fim = inicio.AddSeconds(segundos);

            EmissaoPostDTO post = new EmissaoPostDTO(inicio, carro.Id, rua.Id);

            var emissao = CreateEmissao(post);

            double co2 = CalculoEmissao(emissao.Id);

            EmissaoPutDTO put = new EmissaoPutDTO(emissao.Id, fim, co2);
        }

        public async Task<EmissaoModel?> CreateEmissao(EmissaoPostDTO request) // editar
        {
            EmissaoModel model = new EmissaoModel()
            {
                DataInicio = request.DataInicio,
                VeiculoId = request.VeiculoId,
                RuaId = request.RuaId,
                Veiculo = _context.Veiculos.FirstOrDefault(v => v.Id == request.VeiculoId),
                Rua = _context.Ruas.FirstOrDefault(r => r.Id == request.RuaId),
            };
            await _context.Emissoes.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
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

        public double? GetEmissaoDeTalMes(int mes, int ano) // checar formato, mudar
        {
            return _context.Emissoes.Where(e => e.DataInicio.Month == mes).Where(e => e.DataInicio.Year == ano).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse mês! 404");
        }

        public double? GetEmissaoDeTalDia(int dia, int mes, int ano) // checar formato
        {
            return _context.Emissoes.Where(e => e.DataInicio.Day == dia).Where(e => e.DataInicio.Month == mes).Where(e => e.DataInicio.Year == ano).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse mês! 404");
        }

        public double? GetEmissaoDoUltimoAno()
        {
            return _context.Emissoes.Where(e => (DateTime.Now.Year - e.DataInicio.Year) <= 0).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse ano! 404");
        }

        public double? GetEmissaoDoUltimoDia()
        {
            return _context.Emissoes.Where(e => ((DateTime.Now.Day - e.DataInicio.Day) <= 0) && ((DateTime.Now.Month - e.DataInicio.Month) <= 0) && ((DateTime.Now.Day - e.DataInicio.Day) <= 0)).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse dia! 404");
        }
        
        public double? GetEmissaoDoUltimoMes()
        {
            return _context.Emissoes.Where(e => ((DateTime.Now.Month - e.DataInicio.Month) <= 0) && ((DateTime.Now.Year - e.DataInicio.Year) <= 0)).Select(e => e.CO2).ToList().Sum() ?? throw new ArgumentNullException("Não tem emissões desse mês! 404");
        }
    

        public async Task UpdateEmissao(int id, EmissaoPutDTO request) //editar
        {
            var model = await _context.Emissoes.FirstOrDefaultAsync(e => e.Id == id) ?? throw new ArgumentNullException("Emissão não encontrada! 404");
            model.DataFim = request.DataFim;
            model.CO2 = request.CO2;
            _context.SaveChanges();
        }
    }
}
