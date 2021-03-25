using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using CalculaJuros.Application.UseCases.CalculaJuros;
using CalculaJuros.Application.UseCases.BuscaUrlGit;
using CalculaJuros.Application.Reposistory;
using CalculaJuros.Infrastructure.Repository;

namespace CalculaJuros.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<ICalculaJurosUseCase, CalculaJurosUseCase>();
            services.AddTransient<ICalculaJurosRepository, CalculaJurosRepository>();
            services.AddTransient<IBuscaUrlGitUseCase, BuscaUrlGitUseCase>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Cálculo Juros API",
                        Version = "v1",
                    });

                string path = PlatformServices.Default.Application.ApplicationBasePath;
                string name = PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = Path.Combine(path, $"{name}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Taxa");
            });

        }
    }
}
