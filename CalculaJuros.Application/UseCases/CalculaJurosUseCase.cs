using System;
using System.Threading.Tasks;
using CalculaJuros.Application.Dto;
using CalculaJuros.Application.Reposistory;

namespace CalculaJuros.Application.UseCases
{
    public class CalculaJurosUseCase : ICalculaJurosUseCase
    {
        private readonly ICalculaJurosRepository _calculaJurosRepository;
        public CalculaJurosUseCase(ICalculaJurosRepository calculaJurosRepository)
        {
            _calculaJurosRepository = calculaJurosRepository;
        }


        public async Task<ResultDto<CalculaJurosResponseDto>> Execute(CalculaJurosRequestDto request)
        {
            var result = new ResultDto<CalculaJurosResponseDto>();
            result.Data = new CalculaJurosResponseDto();
            try
            {
                var taxa = await _calculaJurosRepository.BuscaTaxa();

                var jurosComposto = Convert.ToDouble((1 + taxa.TaxaJuros));
                var resultJuros = Convert.ToDecimal(Math.Pow(jurosComposto, request.Tempo)) * request.ValorInicial;

                result.Data.ValorFinal = Math.Truncate(100 * resultJuros) / 100;
                result.Sucess = true;
                result.Message = "Sucesso!";

            }
            catch (Exception)
            {
                result = new ResultDto<CalculaJurosResponseDto>
                {
                    Sucess = false,
                    Message = "Não foi possível realizar o cálculo!"
                };

            }

            return result;
        }
    }
}
