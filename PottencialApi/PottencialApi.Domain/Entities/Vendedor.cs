
using PottencialApi.Domain.Validation;

namespace PottencialApi.Domain.Entities
{
    public sealed class Vendedor : Entity
    {
        public string? Cpf { get; private set; }
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public string? Telefone { get; private set; }

        public Vendedor(int id, string cpf, string nome, string email, string telefone)
        {
            ValidateDomain(cpf, nome, email, telefone);
            DomainExceptionValidation.When(id < 0, "Id inválido!");
            Id = id;
        }

        public Vendedor(string cpf, string nome, string email, string telefone)
        {
            ValidateDomain(cpf, nome, email, telefone);
        }

        public void Update(string cpf, string nome, string email, string telefone)
        {
            ValidateDomain(cpf, nome, email, telefone);
        }

        private void ValidateDomain(string cpf, string nome, string email, string telefone)
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(cpf),
                "Cpf inválido, está null ou vazio!"
            );

            DomainExceptionValidation.When(
                cpf.Length != 11,
                "Cpf, deve-se ter o tamanho de 11!"
            );

            DomainExceptionValidation.When(
                string.IsNullOrEmpty(nome),
                "Nome inválido, está null ou vazio!"
            );

            DomainExceptionValidation.When(
                nome.Length < 3,
                "Nome inválido, deve-se ter o tamanho >= 3!"
            );

            DomainExceptionValidation.When(
                string.IsNullOrEmpty(email),
                "Email inválido, está null ou vazio!"
            );

            DomainExceptionValidation.When(
                string.IsNullOrEmpty(telefone),
                "Telefone inválido, está null ou vazio!"
            );

            Cpf = cpf;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}
