using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PottencialApi.Domain.Entities;

namespace PottencialApi.Infra.Data.EntitiesConfiguration
{
    public class VendedorConfiguration : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.HasKey(ven => ven.Id);

            builder.Property(ven => ven.Nome).HasMaxLength(100).IsRequired();
            builder.Property(ven => ven.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(ven => ven.Email).HasMaxLength(100);
            builder.Property(ven => ven.Telefone).HasMaxLength(30);
        }
    }
}
