using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PottencialApi.Domain.Entities;

namespace PottencialApi.Infra.Data.EntitiesConfiguration
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(ven => ven.Id);

            builder.HasOne(venda => venda.Vendedor)
                .WithMany(vendedor => vendedor.Vendas)
                .HasForeignKey(ven => ven.VendedorId);
        }
    }
}
