using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RuaController : ControllerBase
    {
        private readonly IRuaService _ruaService;

        public RuaController(IRuaService ruaService)
        {
            _ruaService = ruaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RuaGetDTO>>> GetAllRuas()
        {
            try
            {
                var ruas = await _ruaService.GetAllRuas();
                return Ok(ruas);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RuaGetDTO>> GetRuaById(int Id)
        {
            try
            {
                var rua = await _ruaService.GetRuaById(Id);
                return Ok(rua);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("cep/{CEP}")]
        public async Task<ActionResult<RuaGetDTO>> GetRuaByCEP(string CEP)
        {
            try
            {
                var rua = await _ruaService.GetRuaByCEP(CEP);
                return Ok(rua);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("emissao/{Id}/Total")]
        public async Task<ActionResult<double>> GetTotalEmissao(int Id)
        {
            try
            {
                var emissaoTotal = await _ruaService.GetEmissaoTotalRua(Id);
                return Ok(emissaoTotal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("emissao/{Id}/Ano/{ano}")]
        public async Task<ActionResult<double>> GetYearEmissao(int Id, int ano)
        {
            try
            {
                var emissaoAnual = await _ruaService.GetEmissaoAnualRua(Id, ano);
                return Ok(emissaoAnual);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("emissao/{Id}/ano/{ano}/mes/{mes}")]
        public async Task<ActionResult<double>> GetMesEmissao(int Id, int ano, int mes)
        {
            try
            {
                var emissao = await _ruaService.GetEmissaoMesRua(Id, mes, ano);
                return Ok(emissao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("emissao/{Id}/ano/{ano}/mes/{mes}/dia/{dia}")]
        public async Task<ActionResult<double>> GetDiaEmissao(int Id, int ano, int mes, int dia)
        {
            try
            {
                var emissao = await _ruaService.GetEmissaoTalDiaRua(Id, mes, ano, dia);
                return Ok(emissao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("emissao/{Id}/ultimo/dia")]
        public async Task<ActionResult<double>> GetDiaUltimo(int Id)
        {
            try
            {
                var emissao = await _ruaService.GetEmissaoUltimoDia(Id);
                return Ok(emissao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}/emissao/media")]
        public async Task<ActionResult<double>> Media(int Id)
        {
            try
            {
                var emissao = _ruaService.GetEmissaoMediaGeral(Id);
                return Ok(emissao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Regiao/{regiao}")]
        public async Task<ActionResult<double>> GetEmissaoByRegiao(string regiao)
        {
            try
            {
                var emissao = await _ruaService.GetEmissaoRegiao(regiao);
                return Ok(emissao);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("MaisPoluentes")]
        public async Task<ActionResult<List<RuaGetDTO>>> GetRuasMaisPoluentes()
        {
            try{
                var ruas = await _ruaService.GetRuasMaisPoluentes();
                return Ok(ruas);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("MaisPoluentes/5anos")]
        public async Task<ActionResult<List<List<double>>>> GetEmissaoRuasMaisPoluentes5Anos()
        {
            try
            {
                var emissao = await _ruaService.GetEmissoesUltimos5AnosMaisPoluentes();
                return Ok(emissao);
            }catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("MaisPoluentes/5meses")]
        public async Task<ActionResult<List<List<double>>>> GetEmissaoRuasMaisPoluentes5Meses()
        {
            try
            {
                var emissao = await _ruaService.GetEmissoesUltimos5MesesMaisPoluentes();
                return Ok(emissao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> CreateRua(RuaModel rua)
        {
            try
            {
                await _ruaService.CreateRua(rua);
                return Ok("Rua criada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateRua(int Id, RuaModel rua)
        {
            try
            {
                await _ruaService.UpdateRua(Id, rua);
                return Ok("Rua atualizada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
