using Back_End.DTOs;
using Refit;

namespace Back_End.Services.ViaCep
{
    public interface IIntegracao
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepDTO>> GetViaCep(string cep);
    }
}
