using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PottencialApi.Application.Interfaces;
using PottencialApi.Application.Mappings;
using PottencialApi.Application.Services;
using PottencialApi.Domain.Interfaces;
using PottencialApi.Infra.Data.Context;
using PottencialApi.Infra.Data.Repositories;
using FluentValidation;
using PottencialApi.Application.DTOs;
using PottencialApi.Application.Validators;

namespace PottencialApi.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<IVendedorRepository, VendedorRepository>();
            services.AddScoped<IVendedorService, VendedorService>();

            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IVendaService, VendaService>();

            services.AddAutoMapper(typeof(DomainToDTOMapping));

            services.AddScoped<IValidator<VendaPostDTO>, VendaPostDTOValidator>();

            return services;
        }
    }
}
