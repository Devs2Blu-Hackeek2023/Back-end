using Back_End.Data;
using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Camera;
using Back_End.Services.Interfaces;
using Back_End.Services.Trafego;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Services
{
	public class EmissaoService : IEmissaoService
	{
		private readonly DataContext _context;
		private readonly ITrafegoService _trafegoService;
		private readonly ICameraService _cameraService;

		public EmissaoService(DataContext context, ITrafegoService trafegoService, ICameraService cameraService)
		{
			_context = context;
			_trafegoService = trafegoService;
			_cameraService = cameraService;
		}

		public async Task<EmissaoModel> IniciarEmissao()
		{
			var veiculo = await _trafegoService.SortearVeiculoAsync() ?? throw new Exception("Veículo não encontrado.");
			var rua = await _trafegoService.SortearRuaAsync() ?? throw new Exception("Rua não encontrada.");

			DateTime inicio = _cameraService.SetInicio();

			EmissaoPostDTO post = new EmissaoPostDTO(inicio, veiculo.Id, rua.Id);

			var emissao = await CreateEmissao(post);

			return emissao;
		}

		public async Task EncerrarEmissao(EmissaoModel emissao)
		{
			double co2 = await CalculoEmissao(emissao.Id);
			DateTime fim = _cameraService.SetFinal();

			EmissaoPutDTO put = new EmissaoPutDTO(emissao.Id, fim, co2);

			await UpdateEmissao(emissao.Id, put);
		}

		public async Task Emissao()
		{
			var emissao = await IniciarEmissao();
			await EncerrarEmissao(emissao);
		}

        public async Task<double> CalculoEmissao(int id)
        {
            var emissao = await _context.Emissoes.FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception("Emissão não encontrada.");
            var veiculo = await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == emissao.VeiculoId) ?? throw new Exception("Veículo não encontrado.");
            var rua = await _context.Ruas.FirstOrDefaultAsync(r => r.Id == emissao.RuaId) ?? throw new Exception("Rua não encontrada.");
            var tipoCombustivel = veiculo.Combustivel;
            var kmRua = rua.Comprimento;
            var kmL = veiculo.KmL;
            double constante = 0;

            if (tipoCombustivel.ToLower() == "gasolina") constante = 2.39;
            else if (tipoCombustivel.ToLower() == "diesel") constante = 2.64;
            else if (tipoCombustivel.ToLower() == "gás" || tipoCombustivel.ToLower() == "gas" || tipoCombustivel.ToLower() == "gnv") constante = 1.66;
            else if (tipoCombustivel.ToLower() == "álcool" || tipoCombustivel.ToLower() == "alcool" || tipoCombustivel.ToLower() == "etanol") constante = 0.50;
            else throw new Exception("Tipo de combustível inexistente.");

            double litros = kmRua / kmL;

            double resultado = litros * constante;

            return resultado;
        }


        public async Task<EmissaoModel> CreateEmissao(EmissaoPostDTO request)
		{
			EmissaoModel model = new EmissaoModel()
			{
				DataInicio = request.DataInicio,
				VeiculoId = request.VeiculoId,
				RuaId = request.RuaId
			};
			await _context.Emissoes.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task DeleteEmissao(int id)
		{
			var request = await _context.Emissoes.FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception("Emissão não encontrada.");
			_context.Emissoes.Remove(request);
			await _context.SaveChangesAsync();
		}

		public async Task<List<EmissaoModel>> GetAllEmissao()
		{
			return await _context.Emissoes.ToListAsync() ?? throw new Exception("Emissão não encontrada.");
		}

		public async Task<EmissaoModel> GetEmissaoById(int id)
		{
			return await _context.Emissoes.FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception("Emissão não encontrada.");
		}

		public double? GetEmissaoTotal()
		{
			return _context.Emissoes.Select(e => e.CO2).ToList().Sum();
		}

		public double? GetEmissaoDeTalAno(int ano)
		{
			return _context.Emissoes.Where(e => e.DataInicio.Year == ano).Select(e => e.CO2).ToList().Sum() ?? throw new Exception($"Não há emissões registradas no ano {ano}.");
		}

		public double? GetEmissaoDeTalMes(int mes, int ano)
		{
			return _context.Emissoes.Where(e => e.DataInicio.Month == mes).Where(e => e.DataInicio.Year == ano).Select(e => e.CO2).ToList().Sum() ?? throw new Exception($"Não há emissões registradas no mês de {mes}/{ano}.");
		}

		public double? GetEmissaoDeTalDia(int dia, int mes, int ano)
		{
			return _context.Emissoes.Where(e => e.DataInicio.Day == dia).Where(e => e.DataInicio.Month == mes).Where(e => e.DataInicio.Year == ano).Select(e => e.CO2).ToList().Sum() ?? throw new Exception($"Não há emissões registradas no dia {dia}/{mes}/{ano}.");
		}

		public double? GetEmissaoDoUltimoAno()
		{
			return _context.Emissoes.Where(e => (DateTime.Now.Year - e.DataInicio.Year) <= 0).Select(e => e.CO2).ToList().Sum() ?? throw new Exception($"Não há emissões registradas no último ano.");
		}

		public double? GetEmissaoDoUltimoDia()
		{
			return _context.Emissoes.Where(e => ((DateTime.Now.Day - e.DataInicio.Day) <= 0) && ((DateTime.Now.Month - e.DataInicio.Month) <= 0) && ((DateTime.Now.Day - e.DataInicio.Day) <= 0)).Select(e => e.CO2).ToList().Sum() ?? throw new Exception("Não há emissões registradas no último dia.");
		}

		public double? GetEmissaoDoUltimoMes()
		{
			return _context.Emissoes.Where(e => ((DateTime.Now.Month - e.DataInicio.Month) <= 0) && ((DateTime.Now.Year - e.DataInicio.Year) <= 0)).Select(e => e.CO2).ToList().Sum() ?? throw new Exception("Não há emissões registradas no último mês.");
		}

        public double? GetEmissaoMediaGeral()
        {
			var lista = _context.Emissoes.Select(e => e.CO2).ToList();
			var result = lista.Sum() / lista.Count;
			return result;
        }

        public async Task UpdateEmissao(int id, EmissaoPutDTO request)
		{
			var model = await _context.Emissoes.FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception("Emissão não encontrada.");
			model.DataFim = request.DataFim;
			model.CO2 = request.CO2;
			_context.SaveChanges();
		}
	}
}

