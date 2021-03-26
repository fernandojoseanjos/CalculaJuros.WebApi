using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculaJuros.Application.UseCases.CalculaJuros;
using CalculaJuros.Application.UseCases.BuscaUrlGit;

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
        /// Calcula juros composto
        /// </summary>
        /// <param name="tempo">em meses</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>Este método tem o objetivo de calcular o valor do juros composto.</para>
        /// </remarks>
        
       
        [HttpGet("calculajuros {valorInicial},{tempo}")]
        public async Task<IActionResult> Get(decimal valorInicial, int tempo)
        {
            var output = await _calculaJurosUseCase.Execute(valorInicial, tempo);
            return new JsonResult(output);
        }

        /// <summary>
        /// Urls projetos
        /// </summary>
        /// <remarks>Este método de como objetivo retornar as urls dos projeto no GitHub.</remarks>
        /// <returns></returns>
        [HttpGet("showmethecode")]
        public IActionResult GetUrl()
        {
            var output = _buscaUrlGitUseCase.Execute();
            return new JsonResult(output);
        }
    }
}
