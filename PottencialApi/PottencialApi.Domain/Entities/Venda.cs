
using PottencialApi.Domain.Validation;

namespace PottencialApi.Domain.Entities
{
    public sealed class Venda : Entity
    {
        public DateTime DataCriacao { get; private set; }
        public VendaStatus VendaStatus { get; private set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<VendaDetalhe> Itens { get; set; }

        public Venda(DateTime dataCriacao, VendaStatus vendaStatus, int vendedorId)
        {
            Itens = new List<VendaDetalhe>();
            DataCriacao = dataCriacao;
            VendaStatus = vendaStatus;
            VendedorId = vendedorId;
        }

        private static bool ValidarAtualizacaoStatusVenda(VendaStatus vendaStatusAntigo, VendaStatus vendaStatusNovo)
        {
            var statusVendas = new Dictionary<VendaStatus, List<VendaStatus>>()
            {
                { 
                    VendaStatus.AguardandoPagamento, new List<VendaStatus>() 
                    {
                        VendaStatus.PagamentoAprovado,
                        VendaStatus.Cancelada,
                        VendaStatus.AguardandoPagamento
                    }
                },
                {
                    VendaStatus.PagamentoAprovado, new List<VendaStatus>()
                    {
                        VendaStatus.EnviadoParaTransportadora,
                        VendaStatus.Cancelada,
                        VendaStatus.PagamentoAprovado
                    }
                },
                {
                    VendaStatus.EnviadoParaTransportadora, new List<VendaStatus>()
                    {
                        VendaStatus.Entregue,
                        VendaStatus.EnviadoParaTransportadora
                    }
                },
                {
                    VendaStatus.Cancelada, new List<VendaStatus>()
                    {
                        VendaStatus.Cancelada
                    }
                },
                {
                    VendaStatus.Entregue, new List<VendaStatus>()
                    {
                        VendaStatus.Entregue
                    }
                }
            };
            
            if(statusVendas.ContainsKey(vendaStatusAntigo) && statusVendas[vendaStatusAntigo].Contains(vendaStatusNovo))
            {
                return true;
            }
            return false;
        }

        public void Update(VendaStatus vendaStatus, int vendedor)
        {
            ValidateDomain(vendaStatus, vendedor);
        }

        private void ValidateDomain(VendaStatus vendaStatus, int vendedor)
        {
            DomainExceptionValidation.When(vendedor < 0, "Vendedor não preenchido!");
            DomainExceptionValidation.When(!ValidarAtualizacaoStatusVenda(this.VendaStatus, vendaStatus), "Erro atualização status venda!");

            VendaStatus = vendaStatus;
            VendedorId = vendedor;
        }
    }
}
