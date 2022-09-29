using PottencialApi.Domain.Validation;

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

        public VendaDetalhe(int numeroItem, decimal quantidade, decimal precoUnitario, decimal desconto, decimal acrescimo)
        {
            ValidateDomain(numeroItem, quantidade, precoUnitario, desconto, acrescimo);
        }

        public void Update(int numeroItem, decimal quantidade, decimal precoUnitario, decimal desconto, decimal acrescimo)
        {
            ValidateDomain(numeroItem, quantidade, precoUnitario, desconto, acrescimo);
        }

        private void ValidateDomain(int numeroItem, decimal quantidade, decimal precoUnitario, decimal desconto, decimal acrescimo)
        {
            DomainExceptionValidation.When(numeroItem < 1, "Numero do item iválido!");
            DomainExceptionValidation.When(quantidade <= 0, "Quantidade não pode ser menor ou igual a zero!");

            NumeroItem = numeroItem;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Desconto = desconto;
            Acrescimo = acrescimo;
        }
    }
}
