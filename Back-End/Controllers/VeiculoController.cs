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
        public async Task<ActionResult> CreateVeiculo(VeiculoModel request)
        {
            try
            {
                await _veiculoService.CreateVeiculo(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVeiculo(int id)
        {
            try
            {
                await _veiculoService.DeleteVeiculo(id);
                return Ok();
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

        [HttpGet("/veiculo/{id}/emissao")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoModel>> GetVeiculoById(int id)
        {
            try
            {

                var result = await _veiculoService.GetVeiculoById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{placa}")]
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVeiculo(int id, VeiculoPutDTO request)
        {
            try
            {
                await _veiculoService.UpdateVeiculo(id, request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }


    }
}
