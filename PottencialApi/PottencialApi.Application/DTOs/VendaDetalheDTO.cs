
namespace PottencialApi.Application.DTOs
{
    public class VendaDetalheDTO
    {
        public int Id { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }
        public int ProdutoId { get; set; }
    }
}
