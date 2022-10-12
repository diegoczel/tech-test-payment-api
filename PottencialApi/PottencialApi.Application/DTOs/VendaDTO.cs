
namespace PottencialApi.Application.DTOs
{
    public class VendaDTO
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public int VendaStatus { get; set; }
        public int VendedorId { get; set; }
        public List<VendaDetalheDTO> VendaDetalhe { get; set; }
    }
}
