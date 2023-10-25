using Back_End.Data;
using Back_End.Model;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Services.Camera
{
	public class CameraService : ICameraService
	{
		private readonly DataContext _context;
		private readonly Random _random;

		public CameraService(DataContext context)
		{
			_context = context;
			_random = new Random();
		}

		public async Task<RuaModel?> SortearRuaAsync()
		{
			int totalRuas = await _context.Ruas.CountAsync();

			if (totalRuas == 0) return null;
			else
			{
				int randomIndex = _random.Next(0, totalRuas);
				RuaModel? randomRua = await _context.Ruas.OrderBy(r => r.Id)
					.Skip(randomIndex)
					.Take(1)
					.FirstOrDefaultAsync();

				return randomRua;
			}
		}

		public async Task<VeiculoModel?> SortearVeiculoAsync()
		{
			int totalVeiculos = await _context.Veiculos.CountAsync();

			if (totalVeiculos == 0) return null;
			else
			{
				int randomIndex = _random.Next(0, totalVeiculos);
				VeiculoModel? randomVeiculo = await _context.Veiculos.OrderBy(v => v.Id)
					.Skip(randomIndex)
					.Take(1)
					.FirstOrDefaultAsync();

				return randomVeiculo;
			}
		}

		public int SetTempo(int minSecs, int maxSecs) { return _random.Next(minSecs, maxSecs + 1); }
	}
}
