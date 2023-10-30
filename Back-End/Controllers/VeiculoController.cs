using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateVeiculo(VeiculoPostDTO request)
        {
            try
            {
                await _veiculoService.CreateVeiculo(request);
                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteVeiculo(int Id)
        {
            try
            {
                await _veiculoService.DeleteVeiculo(Id);
                return Ok("Veículo deletado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<VeiculoModel>>> GetVeiculos()
        {
            try
            {
                var result = await _veiculoService.GetAllVeiculos();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Proprietario/{id}")]
        public async Task<ActionResult<List<VeiculoGetDTO>>> GetVeiculosByProprietarioId(int id)
        {
            try
            {
                var result = await _veiculoService.GetVeiculoByProprietarioId(id);
                return Ok(result);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("/veiculo/{Id}/Emissao/dia/{dia}/mes/{mes}/ano/{ano}")]
        public async Task<ActionResult<double>> GetEmissaoDiaByVeiculoId(int Id, int dia, int mes, int ano)
        {
            try
            {
                var result = await _veiculoService.GetEmissaoDiaVeiculo(Id, dia, mes, ano);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("emissao/categoria/{categoria}")]
        public async Task<ActionResult<double?>> GetMediaGeralDeEmissoesByCategoria(string categoria)
        {
            try
            {

                var result = _veiculoService.GetMediaGeralDeEmissoesByCategoria(categoria);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("emissao/veiculo/{Id}/6meses")]
        public async Task<ActionResult<List<double?>>> GetEmissaoUltimos6Meses(int Id)
        {
            try
            {
                var result = _veiculoService.GetEmissoesUltimos6MesesByVeiculoId(Id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<VeiculoModel>> GetVeiculoById(int Id)
        {
            try
            {

                var result = await _veiculoService.GetVeiculoById(Id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Placa/{placa}")]
        public async Task<ActionResult<VeiculoModel>> GetVeiculoByPlaca(string placa)
        {
            try
            {

                var result = await _veiculoService.GetVeiculoByPlaca(placa);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateVeiculo(int Id, VeiculoPutDTO request)
        {
            try
            {
                await _veiculoService.UpdateVeiculo(Id, request);
                return Ok("Cadastro alterado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }


    }
}
