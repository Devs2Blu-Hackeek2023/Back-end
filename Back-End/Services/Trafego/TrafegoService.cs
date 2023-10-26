using Back_End.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Back_End.Services.Trafego
{
	public class TrafegoService : ITrafegoService
	{
		private readonly string _apiURL = "https://localhost:7205";
		private readonly HttpClient _httpClient;
		private readonly Random _random;
		private readonly System.Timers.Timer _timer;

		public TrafegoService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_random = new Random();
			_timer = new System.Timers.Timer();

			IniciarTimer();
		}

		private void SetRandomIntervalo(int minSegs, int maxSegs) { _timer.Interval = _random.Next(minSegs, maxSegs); }

		private void IniciarTimer()
		{
			_timer.Elapsed += (sender, e) => IniciarTrafego();
			SetRandomIntervalo(10, 300);
			_timer.AutoReset = true;
			_timer.Start();
		}

		public async Task IniciarTrafego()
		{
			try
			{
				EmissaoPostDTO emissao = new EmissaoPostDTO()
				{
					Id = null,
					DataInicio = null,
					VeiculoId = null,
					RuaId = null
				};

				string emissaoJSON = JsonConvert.SerializeObject(emissao);
				var content = new StringContent(emissaoJSON, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await _httpClient.PostAsync($"{_apiURL}/emissao/ia", content);

				if (response.IsSuccessStatusCode)
				{
					string responseContent = await response.Content.ReadAsStringAsync();
				}
				else throw new Exception(response.StatusCode.ToString());
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
