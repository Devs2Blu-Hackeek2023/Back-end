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
        private readonly List<string> Norte = new List<string> {"Badenfurt","Fidélis","Itoupava Central","Itoupavazinha","Salto do Norte","Testo Salto","Vila Itoupava" };
        private readonly List<string> Sul = new List<string> { "Da Glória", "Garcia", "Progresso", "Ribeirão Fresco", "Valparaíso", "Vila Formosa" };
        private readonly List<string> Leste = new List<string> { "Fortaleza", "Fortaleza Alta", "Itoupava Norte", "Nova Esperança", "Ponta Aguda", "Tribess", "Vorstadt" };
        private readonly List<string> Oeste = new List<string> { "Água Verde", "Do Salto", "Escola Agrícola", "Passo Manso", "Salto Weissbach", "Velha", "Velha Central", "Velha Grande" };
        private readonly List<string> Central = new List<string> { "Boa Vista", "Bom Retiro", "Centro", "Itoupava Seca", "Jardim Blumenau", "Victor Konder", "Vila Nova" };
        private readonly Dictionary<string,List<string>> Regioes;
        
        public RuaService(DataContext dataContext)
        {
            _dataContext = dataContext;
            Regioes = new Dictionary<string, List<string>> { { "Norte", Norte }, { "Sul", Sul }, { "Leste", Leste }, { "Oeste", Oeste }, { "Central", Central } };

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
                 .Where(r => r.RuaId == Id && r.DataInicio.Month == mes && r.DataInicio.Year == ano && r.DataInicio.Day == dia)
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

        public async Task<double?> GetEmissaoBairro(string bairro)
        {
            var emissoes = await GetAllRuas();
            var result = new List<double?>();

            foreach (var e in emissoes)
            {
                if (e.bairro.Equals(bairro)) result.Add(e.co2Total);
            }

            return result.Count > 0 || result != null ? result.Sum() : null;
        }

        public async Task<List<RuaGetDTO>> GetRuasMaisPoluentes()
        {
            var ruas = await _dataContext.Ruas.ToListAsync();
            var ruasDTO = new List<RuaGetDTO>();

            foreach (var rua in ruas)
            {
                ruasDTO.Add(await GetRuaByCEP(rua.CEP));
            }

            return ruasDTO.OrderByDescending(r => r.co2Total).Take(5).ToList();
        }

        public async Task<List<List<double?>>> GetEmissoesUltimos5AnosMaisPoluentes()
        {
            var ruas = await GetRuasMaisPoluentes();
            var emissoesRuas = new List<List<double?>>();

            foreach (var rua in ruas)
            {
                var emissoes = new List<double?>();
                for (int i = 0 ; i < 5; i++)
                {
                    emissoes.Add(_dataContext.Emissoes.Where(e => e.RuaId == rua.Id && e.DataFim.Value.Year == DateTime.Now.Year - i).Sum(e => e.CO2));
                }
                emissoesRuas.Add(emissoes);
            }

            return emissoesRuas;
        }

       public async Task<List<List<double?>>> GetEmissoesUltimos5MesesMaisPoluentes()
        {
            var ruas = await GetRuasMaisPoluentes();
            var emissoesRuas = new List<List<double?>>();

            foreach (var rua in ruas)
            {
                var emissoes = new List<double?>();
                for (int i = 0; i < 5; i++)
                {
                    emissoes.Add(_dataContext.Emissoes.Where(e => e.RuaId == rua.Id && e.DataFim.Value.Month == DateTime.Now.Month - i).Sum(e => e.CO2));
                }
                emissoesRuas.Add(emissoes);

            }

            return emissoesRuas;
        }


        public async Task<double?> GetEmissaoRegiao(string regiao)
        {
            var emissoes = await GetAllRuas();
            var result = new List<double?>();

            foreach(var rua in emissoes)
            {
                if(rua.regiao == regiao)
                {
                    result = await _dataContext.Emissoes.Where(e => e.RuaId == rua.Id).Select(e => e.CO2).ToListAsync();
                }
            }

            return result.Sum();
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

            foreach(var regioes in Regioes)
            {
                if (regioes.Value.Contains(result.Neighborhood))
                {
                    regiao = regioes.Key;
                    break;
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
                km = rua.Comprimento,
                co2Total = await GetEmissaoTotalRua(rua.Id)
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
