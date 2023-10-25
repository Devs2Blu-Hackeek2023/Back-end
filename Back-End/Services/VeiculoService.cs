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
        public async Task CreateVeiculo(VeiculoDTO request)
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
                ProprietarioId = request.ProprietarioId
            };

            _dataContext.Veiculos.Add(veiculoModel);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteVeiculo(int id)
        {
            var veiculo = await _dataContext.Veiculos.FirstOrDefaultAsync(v => v.Id == id) ?? throw new ArgumentNullException("Veículo não encontrado! 404");
            _dataContext.Veiculos.Remove(veiculo);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<VeiculoModel>> GetAllVeiculos()
        {
            return await _dataContext.Veiculos.ToListAsync() ?? throw new ArgumentNullException("Veículos não encontrado! 404");
        }

        public Task<double> GetEmissaoAnualVeiculo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetEmissaoMesVeiculo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetEmissaoTotalVeiculo(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VeiculoModel> GetVeiculoById(int id)
        {
            return await _dataContext.Veiculos.FirstAsync(v => v.Id == id) ?? throw new ArgumentNullException("Veículo não encontrado! 404");
        }

        public async Task<VeiculoModel> GetVeiculoByPlaca(string placa)
        {
            return await _dataContext.Veiculos.FirstAsync(v => v.Placa == placa) ?? throw new ArgumentNullException("Veículo não encontrado! 404"); ;
        }

        public Task UpdateVeiculo(int id, VeiculoModel request)
        {
            throw new NotImplementedException();
        }
    }
}
