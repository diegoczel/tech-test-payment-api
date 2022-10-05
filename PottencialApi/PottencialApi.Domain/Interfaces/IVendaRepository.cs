using PottencialApi.Domain.Entities;

namespace PottencialApi.Domain.Interfaces
{
    public interface IVendaRepository
    {
        Task<Venda> CreateAsync(Venda venda);
        Task<Venda> UpdateAsync(Venda venda);
    }
}
