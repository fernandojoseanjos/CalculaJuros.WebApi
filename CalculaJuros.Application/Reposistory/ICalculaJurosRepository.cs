using CalculaJuros.Application.Dto;
using System.Threading.Tasks;

namespace CalculaJuros.Application.Reposistory
{
    public interface ICalculaJurosRepository
    {
        Task<TaxaDto> BuscaTaxa();
    }
}
