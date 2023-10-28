using Back_End.Services.Trafego;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrafegoController : ControllerBase
    {
        private readonly ITrafegoService _service;

        public TrafegoController(ITrafegoService service) { _service = service; }

        [HttpPost]
        public async Task<IActionResult> IniciarTrafego()
        {
            try
            {
                await _service.IniciarTrafego();

                return Ok("Tráfego iniciado.");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
