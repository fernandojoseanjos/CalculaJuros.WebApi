using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculaJuros.Application.UseCases.CalculaJuros;
using CalculaJuros.Application.UseCases.BuscaUrlGit;
using CalculaJuros.Application.Dto;

namespace CalculaJuros.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICalculaJurosUseCase _calculaJurosUseCase;
        private readonly IBuscaUrlGitUseCase _buscaUrlGitUseCase;

        public HomeController(ICalculaJurosUseCase calculaJurosUseCase, IBuscaUrlGitUseCase buscaUrlGitUseCase)
        {
            _calculaJurosUseCase = calculaJurosUseCase;
            _buscaUrlGitUseCase = buscaUrlGitUseCase;
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

        /// <summary>
        /// Busca url do projeto no GitHub
        /// </summary>
        /// <returns></returns>
        [HttpGet("showmethecode")]
        public IActionResult GetUrl()
        {
            var output = _buscaUrlGitUseCase.Execute();
            return new JsonResult(output);
        }
    }
}
