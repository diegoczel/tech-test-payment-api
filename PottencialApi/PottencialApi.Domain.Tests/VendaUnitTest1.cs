using PottencialApi.Domain.Validation;
using PottencialApi.Domain.Entities;
using FluentAssertions;
using System;

namespace PottencialApi.Domain.Tests
{
    public class VendaUnitTest1
    {
        #region AtualizarStatusVenda
        [Fact]
        public void AtualizarStatusVenda_AguardandoPagamento_PagamentoAprovado()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.AguardandoPagamento, 1);
            Action action = () => venda.Update(VendaStatus.PagamentoAprovado, 1);
            action.Should().NotThrow();
        }

        [Fact]
        public void AtualizarStatusVenda_AguardandoPagamento_Cancelada()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.AguardandoPagamento, 1);
            Action action = () => venda.Update(VendaStatus.Cancelada, 1);
            action.Should().NotThrow();
        }

        [Fact]
        public void AtualizarStatusVenda_AguardandoPagamento_AguardandoPagamento()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.AguardandoPagamento, 1);
            Action action = () => venda.Update(VendaStatus.AguardandoPagamento, 1);
            action.Should().NotThrow();
        }

        [Fact]
        public void AtualizarStatusVenda_AguardandoPagamento_Outro()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.AguardandoPagamento, 1);
            Action action = () => venda.Update(VendaStatus.Entregue, 1);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void AtualizarStatusVenda_PagamentoAprovado_EnviadoParaTransportadora()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.PagamentoAprovado, 1);
            Action action = () => venda.Update(VendaStatus.EnviadoParaTransportadora, 1);
            action.Should().NotThrow();
        }

        [Fact]
        public void AtualizarStatusVenda_PagamentoAprovado_Cancelada()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.PagamentoAprovado, 1);
            Action action = () => venda.Update(VendaStatus.Cancelada, 1);
            action.Should().NotThrow();
        }

        [Fact]
        public void AtualizarStatusVenda_PagamentoAprovado_PagamentoAprovado()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.PagamentoAprovado, 1);
            Action action = () => venda.Update(VendaStatus.PagamentoAprovado, 1);
            action.Should().NotThrow();
        }

        [Fact]
        public void AtualizarStatusVenda_PagamentoAprovado_Outro()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.PagamentoAprovado, 1);
            Action action = () => venda.Update(VendaStatus.AguardandoPagamento, 1);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void AtualizarStatusVenda_EnviadoParaTransportadora_Entregue()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.EnviadoParaTransportadora, 1);
            Action action = () => venda.Update(VendaStatus.Entregue, 1);
            action.Should().NotThrow();
        }

        [Fact]
        public void AtualizarStatusVenda_EnviadoParaTransportadora_EnviadoParaTransportadora()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.EnviadoParaTransportadora, 1);
            Action action = () => venda.Update(VendaStatus.EnviadoParaTransportadora, 1);
            action.Should().NotThrow();
        }

        [Fact]
        public void AtualizarStatusVenda_EnviadoParaTransportadora_Outro()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.EnviadoParaTransportadora, 1);
            Action action = () => venda.Update(VendaStatus.AguardandoPagamento, 1);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void AtualizarStatusVenda_Cancelada_Cancelada()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.Cancelada, 1);
            Action action = () => venda.Update(VendaStatus.Cancelada, 1);
            action.Should().NotThrow();
        }

        [Fact]
        public void AtualizarStatusVenda_Cancelada_Outro()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.Cancelada, 1);
            Action action = () => venda.Update(VendaStatus.AguardandoPagamento, 1);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void AtualizarStatusVenda_Entregue_Entregue()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.Entregue, 1);
            Action action = () => venda.Update(VendaStatus.Entregue, 1);
            action.Should().NotThrow();
        }

        [Fact]
        public void AtualizarStatusVenda_Entregue_Outro()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.Entregue, 1);
            Action action = () => venda.Update(VendaStatus.AguardandoPagamento, 1);
            action.Should().Throw<Exception>();
        }
        #endregion

        #region AtualizarIdVendedor
        [Fact]
        public void AtualizarIdVendedor_ParaIdInvalido_GeraException()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.Entregue, 1);
            Action action = () => venda.Update(VendaStatus.Entregue, -1);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void AtualizarIdVendedor_ParaIdValido_Ok()
        {
            var venda = new Venda(DateTime.UtcNow, VendaStatus.Entregue, 1);
            Action action = () => venda.Update(VendaStatus.Entregue, 3);
            action.Should().NotThrow();
        }
        #endregion

    }
}
