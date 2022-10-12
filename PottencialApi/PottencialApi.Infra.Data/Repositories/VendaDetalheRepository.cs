using PottencialApi.Domain.Entities;
using PottencialApi.Domain.Interfaces;
using PottencialApi.Infra.Data.Context;

namespace PottencialApi.Infra.Data.Repositories
{
    public class VendaDetalheRepository : IVendaDetalheRepository
    {
        private readonly ApplicationDbContext _context;
        public VendaDetalheRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VendaDetalhe> Create(VendaDetalhe vendaDetalhe)
        {
            _context.VendaDetalhe.Add(vendaDetalhe);
            await _context.SaveChangesAsync();
            return vendaDetalhe;
        }
    }
}
