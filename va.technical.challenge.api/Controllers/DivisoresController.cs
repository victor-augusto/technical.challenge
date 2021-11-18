using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using va.technical.challenge.domain.Dtos.Divisor;
using va.technical.challenge.domain.Interfaces;
using va.technical.challenge.domain.Modelos;

namespace va.technical.challenge.api.Controllers
{
    [ApiController]
    [Route("divisores")]
    public class DivisoresController : Controller
    {
        private readonly IDivisorService _divisorService;

        public DivisoresController(IDivisorService divisorService)
        {
            _divisorService = divisorService ?? throw new ArgumentNullException(nameof(divisorService));
        }

        [HttpGet("numero/{numero}")]
        [ProducesResponseType(typeof(DivisorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BuscarDivisoresAsync(int numero)
        {
            var divisor = await new DivisorRequest(numero).ValidarAsync(ModelState);
            return Ok(await _divisorService.ObterDivisoresAsync(divisor));
        }
    }
}
