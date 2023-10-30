﻿using Back_End.DTOs;
using Back_End.Model;

namespace Back_End.Services.Interfaces
{
    public interface IRuaService
    {
        Task<RuaGetDTO> GetRuaById(int Id);
        Task<RuaGetDTO> GetRuaByCEP(string Cep);
        Task<List<RuaGetDTO>> GetAllRuas();
        Task CreateRua(RuaModel request);
        Task UpdateRua(int Id, RuaModel request);
        Task<List<RuaGetDTO>> GetRuasMaisPoluentes();
        Task<List<List<double?>>> GetEmissoesUltimos5MesesMaisPoluentes();
        Task<List<List<double?>>> GetEmissoesUltimos5AnosMaisPoluentes();

        Task<double> GetEmissaoMesRua(int Id, int mes, int ano);
        Task<double> GetEmissaoAnualRua(int Id, int ano);
        Task<double> GetEmissaoTotalRua(int Id);
        Task<double> GetEmissaoTalDiaRua(int Id, int mes, int ano, int dia);
        Task<double> GetEmissaoUltimoDia(int Id);
        Task<double?> GetEmissaoBairro(string bairro);
        Task<double?> GetEmissaoRegiao(string regiao);
        double? GetEmissaoMediaGeral(int Id);
        Task<List<double?>> GetEmissoesUltimos30Dias(int Id);
    }
}
