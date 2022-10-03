using System.ComponentModel.DataAnnotations;

namespace PottencialApi.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
    }
}
