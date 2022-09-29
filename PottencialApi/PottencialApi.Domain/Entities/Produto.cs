using PottencialApi.Domain.Validation;

namespace PottencialApi.Domain.Entities
{
    public sealed class Produto : Entity
    {
        public string? Nome { get; private set; }
        public decimal PrecoCusto { get; private set; }
        public decimal PrecoVenda { get; private set; }

        public Produto(int id, string nome, decimal precoCusto, decimal precoVenda)
        {
            ValidateDomain(nome, precoCusto, precoVenda);
            DomainExceptionValidation.When(id < 0, "Invalid Id value");

            Id = id;
        }

        public Produto(string nome, decimal precoCusto, decimal precoVenda)
        {
            ValidateDomain(nome, precoCusto, precoVenda);
        }

        public void Update(string nome, decimal precoCusto, decimal precoVenda)
        {
            ValidateDomain(nome, precoCusto, precoVenda);
        }

        private void ValidateDomain(string nome, decimal precoCusto, decimal precoVenda)
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(nome),
                "Nome inválido, está null ou vazio!"
            );

            DomainExceptionValidation.When(
                nome.Length < 3,
                "Nome inválido, deve-se ter o tamanho >= 3!"
            );

            DomainExceptionValidation.When(
                precoCusto <= 0,
                "Preço de custo inválido, deve ser > 0!"
            );

            DomainExceptionValidation.When(
                precoVenda <= 0,
                "Preço de venda inválido, deve ser > 0!"
            );

            Nome = nome;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
        }
    }
}
