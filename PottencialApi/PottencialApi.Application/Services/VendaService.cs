using PottencialApi.Application.DTOs;
using PottencialApi.Application.Interfaces;
using PottencialApi.Domain.Interfaces;
using PottencialApi.Domain.Entities;
using AutoMapper;

namespace PottencialApi.Application.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(VendaDTO venda)
        {
            var vendaEntity = new Venda(venda.DataCriacao, (VendaStatus)venda.VendaStatus, venda.VendedorId);
            foreach (var item in venda.VendaDetalhe)
            {
                var i = new VendaDetalhe(item.Quantidade, item.PrecoUnitario, item.Desconto, item.Acrescimo, item.ProdutoId);
                vendaEntity.Itens.Add(i);
            }

            await _vendaRepository.CreateAsync(vendaEntity);

        }

        public async Task<VendaDTO> GetById(int id)
        {
            var vendaBanco = await _vendaRepository.GetById(id);
            var venda = _mapper.Map<Venda, VendaDTO>(vendaBanco);
            return venda;
        }
    }
}
