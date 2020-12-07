namespace Venda.Api.Models
{
    public class ResponseModel<T>
    {
        public bool Sucesso { get; set; }
        public string MessagemErro { get; set; }
        public T ObjectToSerialize { get; set; }
    }
}