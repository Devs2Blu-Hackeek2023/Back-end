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

		//public async Task<EmissaoModel?> IniciarEmissaoAsync(string CEP)
		//{
		//	EmissaoModel emissao = new EmissaoModel()
		//	{
		//		Veiculo = await SortearVeiculoAsync(),
		//		Rua = await _context.Ruas.Where(r => r.CEP == CEP).FirstOrDefaultAsync(),
		//		DataInicio = DateTime.Now
		//	};

		//	await _context.SaveChangesAsync();

		//	return emissao;
		//}

		//public async Task<EmissaoModel?> FinalizarEmissaoAsync(EmissaoModel? emissao)
		//{

		//}

		// public async CreateEmissao() {Chama Iniciar e finalizar}
	}
}
