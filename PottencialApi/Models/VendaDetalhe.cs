namespace PottencialApi.Models
{
    public class VendaDetalhe
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int NumeroItem { get; set; }
        public Produto Produto { get; set; }
        public double Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }
    }
}
