using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculaJuros.Application.UseCases;
using CalculaJuros.Application.Dto;

namespace CalculaJuros.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoJurosController : ControllerBase
    {
        private readonly ICalculaJurosUseCase _calculaJurosUseCase;

        public CalculoJurosController(ICalculaJurosUseCase calculaJurosUseCase)
        {
            _calculaJurosUseCase = calculaJurosUseCase;
        }

        /// <summary>
        /// Calcula juros
        /// </summary>
        /// <returns></returns>
        [HttpGet("calculajuros")]
        public async Task<IActionResult> Get([FromQuery] CalculaJurosRequestDto request)
        {
            var output = await _calculaJurosUseCase.Execute(request);
            return new JsonResult(output);
        }
    }
}
