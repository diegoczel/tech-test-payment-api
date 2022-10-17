using AutoMapper;
using PottencialApi.Domain.Entities;
using PottencialApi.Application.DTOs;

namespace PottencialApi.Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            
            CreateMap<Vendedor, VendedorDTO>().ReverseMap();
			
            CreateMap<VendaDetalhe, VendaDetalheDTO>().ReverseMap();
            
            CreateMap<Venda, VendaDTO>()
                .ForMember(dest => dest.VendaDetalhe, act => act.MapFrom(src => src.Itens))
                .ReverseMap();
            CreateMap<Venda, VendaPostDTO>()
                .ForMember(dest => dest.VendaDetalhe, act => act.MapFrom(src => src.Itens))
                .ReverseMap();
        }
    }
}
