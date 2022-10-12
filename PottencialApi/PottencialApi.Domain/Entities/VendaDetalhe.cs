using PottencialApi.Domain.Validation;

namespace PottencialApi.Domain.Entities
{
    public sealed class VendaDetalhe : Entity
    {
        public decimal Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal Acrescimo { get; private set; }

        public int VendaId { get; set; }
        public Venda Venda { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }


        public VendaDetalhe(decimal quantidade, decimal precoUnitario, decimal desconto, decimal acrescimo, int produtoId)
        {
            ValidateDomain(quantidade, precoUnitario, desconto, acrescimo, produtoId);
        }

        public void Update(decimal quantidade, decimal precoUnitario, decimal desconto, decimal acrescimo, int produtoId)
        {
            ValidateDomain(quantidade, precoUnitario, desconto, acrescimo, produtoId);
        }

        private void ValidateDomain(decimal quantidade, decimal precoUnitario, decimal desconto, decimal acrescimo, int produtoId)
        {
            DomainExceptionValidation.When(quantidade <= 0, "Quantidade não pode ser menor ou igual a zero!");

            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Desconto = desconto;
            Acrescimo = acrescimo;
            ProdutoId = produtoId;
        }
    }
}
