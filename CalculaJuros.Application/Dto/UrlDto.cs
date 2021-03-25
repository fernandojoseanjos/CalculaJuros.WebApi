namespace CalculaJuros.Application.Dto
{
   public class UrlDto
    {
        private string urlApiTaxa;
        private string urlApiCalculo;

        public string UrlApiTaxa
        {
            get { return urlApiTaxa; }
            set { urlApiTaxa = value; }
        }

        public string UrlApiCalculo
        {
            get { return urlApiCalculo; }
            set { urlApiCalculo = value; }
        }

        public UrlDto()
        {
            this.urlApiTaxa = "https://github.com/fernandojoseanjos/Taxa.WebApi";
            this.urlApiCalculo = "https://github.com/fernandojoseanjos/CalculaJuros.WebApi";
        }
    }


   

}
