using Back_End.Data;
using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly DataContext _dataContext;

        public VeiculoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task CreateVeiculo(VeiculoPostDTO request)
        {
            var veiculoModel = new VeiculoModel
            {
                Placa = request.Placa,
                Modelo = request.Modelo,
                Ano = request.Ano,
                Marca = request.Marca,
                Categoria = request.Categoria,
                Motor = request.Motor,
                Combustivel = request.Combustivel,
                KmL = request.KmL,
                ProprietarioId = request.ProprietarioId,
                Proprietario = _dataContext.Proprietarios.Find(request.ProprietarioId) ?? throw new Exception("Proprietário não encontrado"),
                Modificacoes = request.Modificacoes 
            };

            _dataContext.Veiculos.Add(veiculoModel);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteVeiculo(int id)
        {
            var veiculo = await _dataContext.Veiculos.FirstOrDefaultAsync(v => v.Id == id) ?? throw new Exception("Veículo não encontrado! 404");
            _dataContext.Veiculos.Remove(veiculo);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<VeiculoModel>> GetAllVeiculos()
        {
            return await _dataContext.Veiculos.ToListAsync() ?? throw new Exception("Veículos não encontrado! 404");
        }

        public async Task<double> GetEmissaoDiaVeiculo(int id, DateTime data)
        {
            var veiculo = await _dataContext.Veiculos.FirstOrDefaultAsync(v => v.Id == id) ?? throw new Exception("Veículo não encontrado! 404");

            var totalCO2 = await _dataContext.Emissoes
                .Where(emissao => emissao.VeiculoId == id && emissao.DataInicio.Date == data.Date)
                .Select(emissao => emissao.CO2 ?? 0.0)
                .SumAsync();

            return totalCO2;
        }

        public async Task<VeiculoModel> GetVeiculoById(int id)
        {
            return await _dataContext.Veiculos.FirstAsync(v => v.Id == id) ?? throw new Exception("Veículo não encontrado! 404");
        }

        public async Task<VeiculoModel> GetVeiculoByPlaca(string placa)
        {
            return await _dataContext.Veiculos.FirstAsync(v => v.Placa == placa) ?? throw new Exception("Veículo não encontrado! 404"); ;
        }

        public async Task UpdateVeiculo(int id, VeiculoPutDTO request)
        {
            var veiculoModel = new VeiculoModel
            {
                Placa = request.Placa,
                Combustivel = request.Combustivel,
                KmL = request.KmL,
                ProprietarioId = request.ProprietarioId,
                Proprietario = request.Proprietario,
                Modificacoes = request.Modificacoes
            };

            await _dataContext.SaveChangesAsync();
        }
    }
}
