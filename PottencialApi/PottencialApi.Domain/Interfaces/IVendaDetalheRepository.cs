using PottencialApi.Domain.Entities;

namespace PottencialApi.Domain.Interfaces
{
    public interface IVendaDetalheRepository
    {
        Task<VendaDetalhe> Create(VendaDetalhe vendaDetalhe);
    }
}
