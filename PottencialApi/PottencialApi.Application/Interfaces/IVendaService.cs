﻿using PottencialApi.Application.DTOs;

namespace PottencialApi.Application.Interfaces
{
    public interface IVendaService
    {
        Task CreateAsync(VendaDTO venda);
        Task<VendaDTO> GetById(int id);
    }
}