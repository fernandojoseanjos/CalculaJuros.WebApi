using System.Threading.Tasks;
using CalculaJuros.Application.Dto;

namespace CalculaJuros.Application.UseCases.CalculaJuros
{
    public interface ICalculaJurosUseCase
    {
        Task<ResultDto<CalculaJurosResponseDto>> Execute(CalculaJurosRequestDto request);
    }
}
