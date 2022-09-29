using PottencialApi.Domain.Validation;
using PottencialApi.Domain.Entities;
using FluentAssertions;

namespace PottencialApi.Domain.Tests
{
    public class ProdutoUnitTest1
    {
        [Fact]
        public void CriarProduto_ComDadosValidos_ResultaObjetoOk()
        {
            Action action = () => new Produto(1, "Produto 1", 5.5m, 10m);
            action.Should().NotThrow();
        }

        [Fact]
        public void CriarProduto_ComIdInvalido_ResultaException()
        {
            Action action = () => new Produto(-1, "Produto 1", 5.5m, 10m);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void CriarProduto_ComNomeNull_ResultaException()
        {
            Action action = () => new Produto(11, null, 5.5m, 10m);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void CriarProduto_ComNomeVazio_ResultaException()
        {
            Action action = () => new Produto(11, "", 5.5m, 10m);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void CriarProduto_ComPrecoCustoInvalido_ResultaException()
        {
            Action action = () => new Produto(1, "Produto 1", 0, 10m);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void CriarProduto_ComPrecoVendaInvalido_ResultaException()
        {
            Action action = () => new Produto(1, "Produto 1", 5.5m, -1m);
            action.Should().Throw<Exception>();
        }
    }
}
