using CalculaJuros.Application.Dto;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using CalculaJuros.Application.Reposistory;

namespace CalculaJuros.Infrastructure.Repository
{
    public class CalculaJurosRepository : ICalculaJurosRepository
    {
        public async Task<TaxaDto> BuscaTaxa()
        {
            TaxaDto result;
            try
            {
                HttpResponseMessage response;

                using (HttpClient client = new HttpClient())
                {
                    response = await client.GetAsync("https://localhost:44335/Taxa/taxaJuros");

                }

                result = JsonConvert.DeserializeObject<TaxaDto>(response.Content.ReadAsStringAsync().Result);

            }
            catch (Exception)
            {

                throw;
            }


            return result;
        }
    }
}
