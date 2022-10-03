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

        public async Task CreateAsync(ProdutoDTO produto)
        {
            var produtoEntity = _mapper.Map<Produto>(produto);
            await _produtoRepository.CreateAsync(produtoEntity);
        }

        public async Task<ProdutoDTO> GetByIdAsync(int id)
        {
            var produtoEntity = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task RemoveAsync(ProdutoDTO produto)
        {
            var produtoEntity = _mapper.Map<Produto>(produto);
            await _produtoRepository.RemoveAsync(produtoEntity);
        }

        public async Task UpdateAsync(ProdutoDTO produto)
        {
            var produtoEntity = _mapper.Map<Produto>(produto);
            await _produtoRepository.UpdateAsync(produtoEntity);
        }
    }
}
