﻿
using PottencialApi.Domain.Validation;

namespace PottencialApi.Domain.Entities
{
    public sealed class Venda : Entity
    {
        public DateTime DataCriacao { get; private set; }
        public VendaStatus VendaStatus { get; private set; }

        // IdentificadorPedido ?

        public Vendedor Vendedor { get; set; }
        public ICollection<VendaDetalhe> VendaDetalhe { get; set; }

        /*
        De: Aguardando pagamento Para: Pagamento Aprovado

        De: Aguardando pagamento Para: Cancelada

        De: Pagamento Aprovado Para: Enviado para Transportadora

        De: Pagamento Aprovado Para: Cancelada

        De: Enviado para Transportador. Para: Entregue
        */

        private void ValidarStatusVenda(VendaStatus vendaStatusAntigo, VendaStatus vendaStatusNovo)
        {
            switch (vendaStatusNovo)
            {
                case VendaStatus.PagamentoAprovado:
                    break;
                default:
                    throw new DomainExceptionValidation("VendaStatus inválido");
            }
        }

        public void Update(VendaStatus vendaStatus, Vendedor vendedor)
        {
            ValidateDomain(vendaStatus, vendedor);
        }

        private void ValidateDomain(VendaStatus vendaStatus, Vendedor vendedor)
        {
            DomainExceptionValidation.When(vendedor is null, "Vendedor não preenchido!");

            VendaStatus = vendaStatus;
            Vendedor = vendedor;
        }
    }
}
