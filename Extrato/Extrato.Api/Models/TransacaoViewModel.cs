namespace Extrato.Api.Models
{
    public class TransacaoViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string TipoTransacao { get; set; }
        public decimal Valor { get; set; }
    }

   
}
