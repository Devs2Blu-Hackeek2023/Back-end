using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmissaoController : ControllerBase
    {
        private readonly IEmissaoService _service;
        public EmissaoController(IEmissaoService service) { _service = service; }

        [HttpPost("ia")]
        public async Task<ActionResult> CreateEmissao()
        {
            try
            {
                await _service.Emissao();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmissao(EmissaoPostDTO request)
        {
            try
            {
                await _service.CreateEmissao(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteEmissao(int Id)
        {
            try
            {
                await _service.DeleteEmissao(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult<List<EmissaoModel>>> GetEmissao()
        {
            try
            {
                var result = await _service.GetAllEmissao();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<EmissaoModel>> GetEmissaoById(int Id)
        {
            try
            {

                var result = await _service.GetEmissaoById(Id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("total")]
        public ActionResult<double> GetEmissaoTotal()
        {
            try
            {
                var result = _service.GetEmissaoTotal();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("total/ano/{ano}")]
        public ActionResult<double> GetEmissaoTalAno(int ano)
        {
            try
            {
                var result = _service.GetEmissaoDeTalAno(ano);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("total/mes/{mes}/ano/{ano}")]
        public ActionResult<double> GetEmissaoTalMes(int mes, int ano)
        {
            try
            {
                var result = _service.GetEmissaoDeTalMes(mes, ano);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("total/dia/{dia}/mes/{mes}/ano/{ano}")]
        public ActionResult<double> GetEmissaoTalDia(int dia, int mes, int ano)
        {
            try
            {
                var result = _service.GetEmissaoDeTalDia(dia, mes, ano);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ultimo/ano")]
        public ActionResult<double> GetEmissaoUltimoAno()
        {
            try
            {
                var result = _service.GetEmissaoDoUltimoAno();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ultimo/mes")]
        public ActionResult<double> GetEmissaoUltimoMes()
        {
            try
            {
                var result = _service.GetEmissaoDoUltimoMes();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ultimo/dia")]
        public ActionResult<double> GetEmissaoUltimoDia()
        {
            try
            {
                var result = _service.GetEmissaoDoUltimoDia();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateEmissao(int Id, EmissaoPutDTO request)
        {
            try
            {
                await _service.UpdateEmissao(Id, request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
