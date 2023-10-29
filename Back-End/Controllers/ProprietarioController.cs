using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        private readonly IProprietarioService _service;

        public ProprietarioController(IProprietarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProprietarioModel>>> GetAll()
        {
            try
            {
                var props = await _service.GetAllProprietarios();
                return Ok(props);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<ActionResult<ProprietarioModel>> GetProprietarioById(int Id)
        {
            try
            {
                var prop = await _service.GetProprietarioById(Id);

                return Ok(prop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProprietarioModel>> CreateProprietario(ProprietarioDTO proprietario)
        {
            try
            {
                await _service.CreateProprietario(proprietario);
                return Ok(proprietario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteProprietario(int Id)
        {
            try
            {
                await _service.DeleteProprietario(Id);
                return Ok("Funcionário deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
