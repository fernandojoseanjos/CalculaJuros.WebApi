using System;
using System.Threading.Tasks;
using CalculaJuros.Application.Dto;
using CalculaJuros.Application.Reposistory;

namespace CalculaJuros.Application.UseCases.CalculaJuros
{
    public class CalculaJurosUseCase : ICalculaJurosUseCase
    {

        private readonly ICalculaJurosRepository _calculaJurosRepository;
        public CalculaJurosUseCase(ICalculaJurosRepository calculaJurosRepository)
        {
            _calculaJurosRepository = calculaJurosRepository;
        }


        public async Task<ResultDto<CalculaJurosResponseDto>> Execute(decimal valorInicial, int tempo)
        {
            var result = new ResultDto<CalculaJurosResponseDto>();
            result.Data = new CalculaJurosResponseDto();
            try
            {
                if (valorInicial <= 0 || tempo <= 0)
                {
                    //result.Data.ValorFinal = 0;
                    return result = new ResultDto<CalculaJurosResponseDto>
                    {
                        Sucess = false,
                        Message = "Não é permitido valores menor ou igual a zero!",
                        Data = result.Data
                    };
                }

                var taxa = await _calculaJurosRepository.BuscaTaxa();

                var jurosComposto = Convert.ToDouble((1 + taxa.TaxaJuros));
                var resultJuros = Convert.ToDecimal(Math.Pow(jurosComposto, tempo)) * valorInicial;

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
