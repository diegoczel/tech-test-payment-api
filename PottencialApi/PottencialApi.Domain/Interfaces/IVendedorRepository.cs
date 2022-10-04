using PottencialApi.Domain.Entities;

namespace PottencialApi.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        Task<Vendedor> CreateAsync(Vendedor vendedor);
        Task<Vendedor> GetByIdAsync(int id);
        Task<Vendedor> UpdateAsync(Vendedor vendedor);
        Task<Vendedor> RemoveAsync(Vendedor vendedor);
    }
}
