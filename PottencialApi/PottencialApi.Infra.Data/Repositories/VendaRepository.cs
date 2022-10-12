using Microsoft.EntityFrameworkCore;
using PottencialApi.Domain.Entities;
using PottencialApi.Domain.Interfaces;
using PottencialApi.Infra.Data.Context;

namespace PottencialApi.Infra.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly ApplicationDbContext _context;
        public VendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Venda> CreateAsync(Venda venda)
        {
            _context.Add(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<Venda> GetById(int id)
        {
            return await _context.Vendas.AsNoTracking()
                .Include(vde => vde.Itens)
                .FirstOrDefaultAsync(ven => ven.Id == id);
        }


        public async Task<Venda> UpdateAsync(Venda venda)
        {
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
            return venda;
        }
    }
}
