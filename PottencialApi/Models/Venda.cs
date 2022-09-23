namespace PottencialApi.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataIncremento { get; set; }
        public VendaStatus VendaStatus { get; set; }

        public ICollection<VendaDetalhe> vendaDetalhes { get; set; }
    }
}
