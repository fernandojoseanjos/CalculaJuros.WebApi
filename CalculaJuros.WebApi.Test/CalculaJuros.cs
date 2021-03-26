using CalculaJuros.Application.UseCases.CalculaJuros;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CalculaJuros.WebApi.Test
{
    public class CalculaJuros : IClassFixture<IntegrationTestFixture>
    {
        private readonly ICalculaJurosUseCase _calculaJurosUseCase;

        public CalculaJuros(IntegrationTestFixture fixture)
        {
            _calculaJurosUseCase = fixture.ServiceProvider.GetRequiredService<ICalculaJurosUseCase>();
        }

        [Theory]
        [InlineData(100, 5, true)]
        [InlineData(100, 10, true)]
        [InlineData(0, 0, false)]
        [InlineData(0, 5, false)]
        [InlineData(5, 0, false)]
        [InlineData(-1, 0, false)]
        [InlineData(-1, -2, false)]

        public void BuscandoTaxa(decimal valorInicial, int tempo, bool esperado)
        {
            var resultado = _calculaJurosUseCase.Execute(valorInicial, tempo).Result.Sucess;
            Assert.Equal(esperado, resultado);
        }
    }
}
