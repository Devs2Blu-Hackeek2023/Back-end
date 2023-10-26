using Back_End.DTOs;

namespace Back_End.Services.ViaCep
{
    public interface IViaCep
    {
        Task<ViaCepDTO> _GetViaCep(string cep);
    }
}
