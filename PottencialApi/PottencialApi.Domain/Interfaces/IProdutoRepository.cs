using PottencialApi.Domain.Entities;

namespace PottencialApi.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> CreateAsync(Produto produto);
        Task<Produto> GetByIdAsync(int id);
        Task<Produto> UpdateAsync(Produto produto);
        Task<Produto> RemoveAsync(Produto produto);
    }
}
