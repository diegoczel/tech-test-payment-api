using PottencialApi.Application.Interfaces;
using PottencialApi.Domain.Interfaces;
using AutoMapper;
using PottencialApi.Application.DTOs;
using PottencialApi.Domain.Entities;

namespace PottencialApi.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDTO> CreateAsync(ProdutoDTO produto)
        {
            var produtoEntity = _mapper.Map<Produto>(produto);
            var produtoBanco = await _produtoRepository.CreateAsync(produtoEntity);

            return _mapper.Map<Produto, ProdutoDTO>(produtoBanco);
        }

        public async Task<ProdutoDTO> GetByIdAsync(int id)
        {
            var produtoEntity = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtos = await _produtoRepository.GetProdutos();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task RemoveAsync(int id)
        {
            var produtoEntity = _produtoRepository.GetByIdAsync(id).Result;
            await _produtoRepository.RemoveAsync(produtoEntity);
        }

        public async Task UpdateAsync(ProdutoDTO produto)
        {
            var produtoEntity = _mapper.Map<Produto>(produto);
            await _produtoRepository.UpdateAsync(produtoEntity);
        }
    }
}
