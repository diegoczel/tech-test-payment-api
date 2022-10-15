using PottencialApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PottencialApi.Application.DTOs
{
    public class VendaStatusDTO
    {
        [Required]
        public VendaStatus VendaStatus { get; set; }
    }
}
