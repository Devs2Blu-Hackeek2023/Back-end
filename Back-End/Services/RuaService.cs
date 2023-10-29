using Back_End.Data;
using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ViaCep;
using static System.Net.Mime.MediaTypeNames;

namespace Back_End.Services
{
    public class RuaService : IRuaService
    {
        private readonly DataContext _dataContext;
        private readonly List<string> RNorte = new List<string> {"Badenfurt","Fidélis","Itoupava Central","Itoupavazinha","Salto do Norte","Testo Salto","Vila Itoupava" };
        private readonly List<string> RSul = new List<string> { "Da Glória", "Garcia", "Progresso", "Ribeirão Fresco", "Valparaíso", "Vila Formosa" };
        private readonly List<string> RLeste = new List<string> { "Fortaleza", "Fortaleza Alta", "Itoupava Norte", "Nova Esperança", "Ponta Aguda", "Tribess", "Vorstadt" };
        private readonly List<string> ROeste = new List<string> { "Água Verde", "Do Salto", "Escola Agrícola", "Passo Manso", "Salto Weissbach", "Velha", "Velha Central", "Velha Grande" };
        private readonly List<string> RCentral = new List<string> { "Boa Vista", "Bom Retiro", "Centro", "Itoupava Seca", "Jardim Blumenau", "Victor Konder", "Vila Nova" };
        private readonly List<List<string>> Regioes;
        
        public RuaService(DataContext dataContext)
        {
            _dataContext = dataContext;
            Regioes = new List<List<string>> { RCentral, RSul, RNorte, RLeste, ROeste };

        }

        public async Task CreateRua(RuaModel request)
        {
            var rua = _dataContext.Ruas.FirstOrDefault(c => c.CEP == request.CEP);
            //  if(rua.CEP == request.CEP) throw new Exception("Cep já cadastrado!");
            _dataContext.Ruas.Add(request);
            await _dataContext.SaveChangesAsync();
        }


        public async Task<List<RuaGetDTO>> GetAllRuas()
        {
            var ruas = await _dataContext.Ruas.ToListAsync() ?? throw new ArgumentNullException("Rua não encontrada! 404");
            var retorno = new List<RuaGetDTO>();
            foreach (var rua in ruas)
            {
                retorno.Add(await GetRuaByCEP(rua.CEP));
            }

            return retorno;
        }

        public async Task<double> GetEmissaoAnualRua(int Id, int ano)
        {
            var emissoes = await _dataContext.Emissoes
                .Where(r => r.RuaId == Id && r.DataInicio.Year == ano)
                .Select(e => e.CO2)
                .SumAsync() ?? throw new ArgumentNullException("Não tem emissões desse ano! 404");

            return emissoes;
        }

        public async Task<double> GetEmissaoMesRua(int Id, int mes, int ano)
        {
            var emissoes = await _dataContext.Emissoes
                 .Where(r => r.RuaId == Id && r.DataInicio.Month == mes && r.DataInicio.Year == ano)
                 .Select(e => e.CO2)
                 .SumAsync() ?? throw new ArgumentNullException("Não tem emissões desse mês! 404");

            return emissoes;
        }

        public async Task<double> GetEmissaoTalDiaRua(int Id, int mes, int ano, int dia)
        {
            var emissoes = await _dataContext.Emissoes
                 .Where(r => r.RuaId == Id && r.DataInicio.Month == mes && r.DataInicio.Year == ano && r.DataInicio.DayOfYear == dia)
                 .Select(e => e.CO2)
                 .SumAsync() ?? throw new ArgumentNullException("Não tem emissões desse mês! 404");

            return emissoes;
        }

        public async Task<double> GetEmissaoUltimoDia(int Id)
        {
            var emissoes = await _dataContext.Emissoes
                 .Where(e => ((DateTime.Now.Day - e.DataInicio.Day) <= 0) && ((DateTime.Now.Month - e.DataInicio.Month) <= 0) && ((DateTime.Now.Day - e.DataInicio.Day) <= 0) && e.RuaId == Id)
                 .Select(e => e.CO2)
                 .SumAsync() ?? throw new ArgumentNullException("Não tem emissões desse mês! 404");

            return emissoes;
        }

        public double? GetEmissaoMediaGeral(int Id)
        {
            var lista = _dataContext.Emissoes.Where(e => e.RuaId == Id).Select(e => e.CO2).ToList();
            var result = lista.Sum() / lista.Count;
            return result;
        }

        public async Task<double> GetEmissaoTotalRua(int Id)
        {
            return _dataContext.Emissoes.Where(r => r.RuaId == Id).Select(e => e.CO2).Sum() ?? throw new Exception("Não há emissões nessa rua! 404");
        }

        public async Task<RuaGetDTO> GetRuaByCEP(string Cep)
        {

            var result = new ViaCepClient().Search(Cep);
            var rua = await _dataContext.Ruas.FirstOrDefaultAsync(c => c.CEP == Cep) ?? throw new Exception("Cep não encontrado");
            string regiao = null;
            if (!(RSul.Contains(result.Neighborhood) || ROeste.Contains(result.Neighborhood) || RLeste.Contains(result.Neighborhood) || RNorte.Contains(result.Neighborhood) || RCentral.Contains(result.Neighborhood))) throw new Exception("Bairo não encontrado");


            foreach(var regioes in Regioes)
            {
                foreach(var bairro in regioes)
                {
                    if(bairro.ToLower() == result.Neighborhood.ToLower())
                    {
                         regiao = bairro;
                    }
                }
            }
            if (regiao is null) throw new Exception("Bairro não encontrado");

            RuaGetDTO resposta = new RuaGetDTO()
            {
                Id = rua.Id,
                cep = Cep,
                rua = result.Street,
                regiao = regiao,
                bairro = result.Neighborhood,
                cidade = result.City,
                uf = result.StateInitials,
                km = rua.Comprimento
            };
            return resposta;
        }

        public async Task<RuaGetDTO> GetRuaById(int Id)
        {
            var rua = await _dataContext.Ruas.FirstAsync(r => r.Id == Id) ?? throw new ArgumentNullException("Rua não encontrada! 404");
            return await GetRuaByCEP(rua.CEP);
        }

        public async Task UpdateRua(int Id, RuaModel request)
        {
            var model = await _dataContext.Ruas.FirstOrDefaultAsync(r => r.Id == Id) ?? throw new Exception("Rua inexistente");
            if (model.Id != Id) throw new Exception("Ids diferentes!");


            model.CEP = request.CEP;
            model.Comprimento = request.Comprimento;

            await _dataContext.SaveChangesAsync();
        }
    }
}
