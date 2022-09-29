
namespace PottencialApi.Domain.Entities
{
    public sealed class VendaDetalhe : Entity
    {
        public int NumeroItem { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal Acrescimo { get; private set; }

        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
    }
}
