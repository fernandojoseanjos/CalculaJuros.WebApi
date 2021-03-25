using System.Threading.Tasks;
using CalculaJuros.Application.Dto;

namespace CalculaJuros.Application.UseCases
{
    public interface ICalculaJurosUseCase
    {
        Task<ResultDto<CalculaJurosResponseDto>> Execute(CalculaJurosRequestDto request);
    }
}
