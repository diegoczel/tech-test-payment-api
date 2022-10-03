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
        }
    }
}
