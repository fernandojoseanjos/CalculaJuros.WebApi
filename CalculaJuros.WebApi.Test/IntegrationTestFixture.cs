using CalculaJuros.Application.Reposistory;
using CalculaJuros.Application.UseCases.CalculaJuros;
using CalculaJuros.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CalculaJuros.WebApi.Test
{
    public class IntegrationTestFixture
    {
        public IntegrationTestFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ICalculaJurosUseCase, CalculaJurosUseCase>();
            serviceCollection.AddTransient<ICalculaJurosRepository, CalculaJurosRepository>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
        public ServiceProvider ServiceProvider { get; private set; }
    }
}
