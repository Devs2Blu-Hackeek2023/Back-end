using Back_End.Data;
using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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
            //ProprietarioModel prop = new ProprietarioModel();
            VeiculoModel vei = new VeiculoModel();
            vei.Placa = request.Placa;
            vei.Modelo = request.Modelo;

            vei.Ano = request.Ano;
            vei.Marca = request.Marca;
            vei.Categoria = request.Categoria;
            vei.Motor = request.Motor;
            vei.Combustivel = request.Combustivel;
            vei.KmL = request.KmL;
            vei.Modificacoes = request.Modificacoes;
            vei.ProprietarioId = request.ProprietarioId;
            vei.Proprietario = await _dataContext.Proprietarios.FirstOrDefaultAsync(i => i.Id == request.ProprietarioId) ?? throw new Exception("Proprietário não existe");


            _dataContext.Veiculos.Add(vei);
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
            return await _dataContext.Veiculos.ToListAsync() ?? throw new Exception("Veículos não encontrado!");
        }

        public async Task<double> GetEmissaoDiaVeiculo(int id, DateTime data)
        {
            var veiculo = await _dataContext.Veiculos.FirstOrDefaultAsync(v => v.Id == id) ?? throw new Exception("Veículo não encontrado!");

            var totalCO2 = await _dataContext.Emissoes
                .Where(emissao => emissao.VeiculoId == id && emissao.DataInicio.Date == data.Date)
                .Select(emissao => emissao.CO2 ?? 0.0)
                .SumAsync();

            return totalCO2;
        }

        public async Task<VeiculoModel> GetVeiculoById(int Id)
        {
            var veiculo = await _dataContext.Veiculos.FindAsync(Id);
            if (veiculo is null) throw new Exception("Veículo não encontrado");
            else return veiculo;
            
        }

        public async Task<VeiculoModel> GetVeiculoByPlaca(string placa)
        {
            var veiculo = await _dataContext.Veiculos.FirstOrDefaultAsync(v => v.Placa == placa);
            if (veiculo is null) throw new Exception("Veículo não encontrado");
            else return veiculo;
            
        }

        public async Task UpdateVeiculo(int id, VeiculoPutDTO request)
        {
            var vei = await _dataContext.Veiculos.Include(v => v.Proprietario).FirstOrDefaultAsync(v => v.Id == id);

            if (vei is null)
            {
                throw new Exception("Veículo não encontrado");
            }

            vei.Placa = request.Placa;
            vei.Combustivel = request.Combustivel;
            vei.KmL = request.KmL;
            vei.Modificacoes = request.Modificacoes;
            vei.ProprietarioId = request.ProprietarioId;

            

            vei.Proprietario.NomeCompleto = request.Proprietario.NomeCompleto;
            vei.Proprietario.CPF = request.Proprietario.CPF;
            vei.Proprietario.CNH = request.Proprietario.CNH;
            vei.Proprietario.UsuarioId = request.Proprietario.UsuarioId;



            await _dataContext.SaveChangesAsync();
        }
    }
}
