using FluentValidation;
using PottencialApi.Application.DTOs;

namespace PottencialApi.Application.Validators
{
    public class VendaPostDTOValidator : AbstractValidator<VendaPostDTO>
    {
        public VendaPostDTOValidator()
        {
            RuleFor(ven => ven.VendedorId).GreaterThan(0);
            RuleForEach(ven => ven.VendaDetalhe).NotNull().SetValidator(new VendaDetalhePostValidator());
        }
    }
}
