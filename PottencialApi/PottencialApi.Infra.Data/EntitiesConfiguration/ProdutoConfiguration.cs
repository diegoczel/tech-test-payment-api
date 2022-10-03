using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PottencialApi.Domain.Entities;

namespace PottencialApi.Infra.Data.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(pro => pro.Id);

            builder.Property(pro => pro.Nome).HasMaxLength(100).IsRequired();
            builder.Property(pro => pro.PrecoCusto).HasPrecision(10, 2);
            builder.Property(pro => pro.PrecoVenda).HasPrecision(10, 2);
        }
    }
}
