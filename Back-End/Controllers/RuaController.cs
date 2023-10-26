using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuaController : ControllerBase
    {
        private readonly IRuaService _ruaService;

        public RuaController(IRuaService ruaService)
        {
            _ruaService = ruaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RuaModel>>> GetAllRuas()
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
        public async Task<ActionResult> GetRuaById(int Id)
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

        [HttpGet("{CEP}")]
        public async Task<ActionResult<RuaModel>> GetRuaByCEP(string CEP)
        {
            try
            {
                var rua = await _ruaService.GetRuaByCEP(CEP);
                return Ok(rua);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}/Total")]
        public async Task<ActionResult<double>> GetTotalEmissao(int Id)
        {
            try
            {
                var emissaoTotal = await _ruaService.GetEmissaoTotalRua(Id);
                return Ok(emissaoTotal);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}/Ano")]
        public async Task<ActionResult<double>> GetYearEmissao(int Id)
        {
            try
            {
                var emissaoAnual = await _ruaService.GetEmissaoAnualRua(Id);
                return Ok(emissaoAnual);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}/Mes")]
        public async Task<ActionResult<double>> GetMesEmissao(int Id)
        {
            try
            {
                var emissao = await _ruaService.GetEmissaoMesRua(Id);
                return Ok(emissao);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult> CreateRua(RuaModel rua)
        {
            try
            {
                _ruaService.CreateRua(rua);
                return Ok("Rua criada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateRua(int Id,  RuaModel rua)
        {
            try
            {
                _ruaService.UpdateRua(Id, rua);
                return Ok("Rua atualizada");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
