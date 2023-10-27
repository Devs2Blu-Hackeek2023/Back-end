using Back_End.DTOs;

namespace Back_End.Services.ViaCep
{
    public class ViaCep : IViaCep
    {
        private readonly IIntegracao _integracao;

        public ViaCep(IIntegracao integracao)
        {
            _integracao = integracao;
        }
        public async Task<ViaCepDTO> _GetViaCep(string cep)
        {
            var response = await _integracao.GetViaCep(cep) ?? throw new Exception("Erro na busca de dados");
            if(response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return null;
        }
    }
}
