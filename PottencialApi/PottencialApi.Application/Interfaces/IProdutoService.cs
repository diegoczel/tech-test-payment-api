using PottencialApi.Application.DTOs;

namespace PottencialApi.Application.Interfaces
{
    public interface IProdutoService
    {
        Task CreateAsync(ProdutoDTO produto);
        Task<ProdutoDTO> GetByIdAsync(int id);
        Task UpdateAsync(ProdutoDTO produto);
        Task RemoveAsync(ProdutoDTO produto);
    }
}
