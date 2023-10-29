using Back_End.Data;
using Back_End.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace Back_End.Services.Trafego
{
    public class TrafegoService : ITrafegoService
    {
        private readonly DataContext _context;
        HttpClient http = new HttpClient();
        private readonly string _apiURL = "https://localhost:7205";
        private readonly Random _random;
        private readonly System.Timers.Timer _timer;

        public TrafegoService(DataContext context)
        {
            _context = context;
            _random = new Random();
            _timer = new System.Timers.Timer();

            IniciarTimer();
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

        private void SetRandomIntervalo(int minMiliSecs, int maxMiliSecs) { _timer.Interval = _random.Next(minMiliSecs * 1000, maxMiliSecs * 1000); }

        private void IniciarTimer()
        {
           
            _timer.Elapsed += async (sender, e) => await IniciarTrafego();
            SetRandomIntervalo(50, 200);
            _timer.AutoReset = true;
            _timer.Start();
        }

        public async Task IniciarTrafego()
        {
           
            try
            {
                
                string JSON = JsonConvert.SerializeObject(new { });
                StringContent content = new(JSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await http.PostAsync($"{_apiURL}/emissao/ia", content);

                if (response.IsSuccessStatusCode) { string responseContent = await response.Content.ReadAsStringAsync(); }
                else throw new Exception(response.StatusCode.ToString());
            }
            catch { throw new Exception("Erro ao iniciar tráfego."); }
        }
    }
}
