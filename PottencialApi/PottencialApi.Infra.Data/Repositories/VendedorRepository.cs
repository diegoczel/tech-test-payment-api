using PottencialApi.Domain.Entities;
using PottencialApi.Domain.Interfaces;
using PottencialApi.Infra.Data.Context;

namespace PottencialApi.Infra.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationDbContext _context;
        public VendedorRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<Vendedor> CreateAsync(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();
            return vendedor;
        }

        public async Task<Vendedor> GetByIdAsync(int id)
        {
            return await _context.Vendedores.FindAsync(id) ?? throw new NullReferenceException();
        }

        public async Task<Vendedor> RemoveAsync(Vendedor vendedor)
        {
            _context.Vendedores.Remove(vendedor);
            await _context.SaveChangesAsync();
            return vendedor;
        }

        public async Task<Vendedor> UpdateAsync(Vendedor vendedor)
        {
            _context.Vendedores.Update(vendedor);
            await _context.SaveChangesAsync();
            return vendedor;
        }
    }
}
