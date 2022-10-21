using PottencialApi.Application.Interfaces;
using AutoMapper;
using PottencialApi.Domain.Interfaces;
using PottencialApi.Application.DTOs;
using PottencialApi.Domain.Entities;

namespace PottencialApi.Application.Services
{
    public class VendedorService : IVendedorService
    {
        private readonly IMapper _mapper;
        private readonly IVendedorRepository _vendedorRepository;
        public VendedorService(IMapper mapper, IVendedorRepository vendedorRepository)
        {
            _mapper = mapper;
            _vendedorRepository = vendedorRepository;
        }

        public async Task<VendedorDTO> CreateAsync(VendedorDTO vendedor)
        {
            var vendedorEntity = _mapper.Map<Vendedor>(vendedor);
            var vendedorBanco = await _vendedorRepository.CreateAsync(vendedorEntity);
            return _mapper.Map<Vendedor, VendedorDTO>(vendedorBanco);
        }

        public async Task<VendedorDTO> GetByIdAsync(int id)
        {
            var vendedorEntity = await _vendedorRepository.GetByIdAsync(id);
            return _mapper.Map<VendedorDTO>(vendedorEntity);
        }

        public async Task RemoveAsync(int id)
        {
            var vendedorEntity = _vendedorRepository.GetByIdAsync(id).Result;
            await _vendedorRepository.RemoveAsync(vendedorEntity);
        }

        public async Task UpdateAsync(VendedorDTO vendedor)
        {
            var vendedorEntity = _mapper.Map<Vendedor>(vendedor);
            await _vendedorRepository.UpdateAsync(vendedorEntity);
        }
    }
}
