using System.ComponentModel.DataAnnotations;

namespace PottencialApi.Application.DTOs
{
    public class VendaPostDTO
    {
        //[Required(ErrorMessage = "Vendedor deve ser preenchido!")]
        public int VendedorId { get; set; }

        [Required(ErrorMessage = "A venda deve ter ao menos um item!")]
        [MinLength(1)]
        public List<VendaDetalhePostDTO> VendaDetalhe { get; set; }
    }
}
