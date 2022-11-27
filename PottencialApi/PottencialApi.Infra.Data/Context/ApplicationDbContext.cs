﻿using Microsoft.EntityFrameworkCore;
using PottencialApi.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PottencialApi.Infra.Data.Identity;

namespace PottencialApi.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)       
        { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaDetalhe> VendaDetalhe { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
