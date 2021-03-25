namespace CalculaJuros.Application.Dto
{
    public class ResultDto<T>
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
}
