
using PottencialApi.Domain.Validation;

namespace PottencialApi.Domain.Entities
{
    public sealed class Venda : Entity
    {
        public DateTime DataCriacao { get; private set; }
        public VendaStatus VendaStatus { get; private set; }

        // IdentificadorPedido ?

        //public Vendedor Vendedor { get; set; }
        //public ICollection<VendaDetalhe> VendaDetalhe { get; set; }

        /*
        De: Aguardando pagamento Para: Pagamento Aprovado

        De: Aguardando pagamento Para: Cancelada

        De: Pagamento Aprovado Para: Enviado para Transportadora

        De: Pagamento Aprovado Para: Cancelada

        De: Enviado para Transportador. Para: Entregue
        */

        public void Update(VendaStatus vendaStatus)
        {
            ValidateDomain(vendaStatus);
        }

        private void ValidateDomain(VendaStatus vendaStatus)
        {
            VendaStatus = vendaStatus;
        }
    }
}
