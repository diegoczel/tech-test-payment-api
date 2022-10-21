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

        public async Task<VendaDTO> CreateAsync(VendaPostDTO venda)
        {
            var vendaEntity = new Venda(DateTime.UtcNow, VendaStatus.AguardandoPagamento, venda.VendedorId);
            foreach (var item in venda.VendaDetalhe)
            {
                var i = new VendaDetalhe(item.Quantidade, item.PrecoUnitario, item.Desconto, item.Acrescimo, item.ProdutoId);
                vendaEntity.Itens.Add(i);
            }

            var vendaBanco = await _vendaRepository.CreateAsync(vendaEntity);

            return _mapper.Map<Venda, VendaDTO>(vendaBanco);
        }

        public async Task<VendaDTO> GetById(int id)
        {
            var vendaBanco = await _vendaRepository.GetById(id);
            var venda = _mapper.Map<Venda, VendaDTO>(vendaBanco);
            return venda;
        }

        public async Task<bool> UpdateAsync(int id, VendaStatusDTO vendaStatusDTO)
        {
            var vendaBanco = await _vendaRepository.GetById(id);

            if (vendaBanco is null)
            {
                return false;
            }

            vendaBanco.Update(vendaStatusDTO.VendaStatus, vendaBanco.VendedorId);
            await _vendaRepository.UpdateAsync(vendaBanco);

            return true;

            
        }
    }
}
