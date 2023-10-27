using Azure.Core;
using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
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

        [HttpDelete("Id")]
        public async Task<ActionResult> DeleteVeiculo(int id)
        {
            try
            {
                await _veiculoService.DeleteVeiculo(id);
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

        [HttpGet("/veiculo/{Id}/Emissao")]
        public async Task<ActionResult<double>> GetEmissaoDiaByVeiculoId(int id, DateTime data)
        {
            try
            {
                var result = await _veiculoService.GetEmissaoDiaVeiculo(id, data);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Id")]
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

        [HttpGet("Placa")]
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

        [HttpPut("Id")]
        public async Task<ActionResult> UpdateVeiculo(int id, VeiculoPutDTO request)
        {
            try
            {
                await _veiculoService.UpdateVeiculo(id, request);
                return Ok("Cadastro alterado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }


    }
}
