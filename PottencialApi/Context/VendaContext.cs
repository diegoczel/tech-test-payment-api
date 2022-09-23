using Microsoft.EntityFrameworkCore;
using PottencialApi.Models;

namespace PottencialApi.Context
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options) : base(options) { }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<VendaDetalhe> VendaDetalhes { get; set; }
    }
}
