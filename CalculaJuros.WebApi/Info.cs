using Microsoft.OpenApi.Models;

namespace CalculaJuros.WebApi
{
    internal class Info : OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
    }
}