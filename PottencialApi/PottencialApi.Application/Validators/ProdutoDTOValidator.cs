using FluentValidation;
using PottencialApi.Application.DTOs;

namespace PottencialApi.Application.Validators
{
    public class ProdutoDTOValidator : AbstractValidator<ProdutoDTO>
    {
        public ProdutoDTOValidator()
        {
            RuleFor(pro => pro.Nome).MinimumLength(3).MaximumLength(100);
            RuleFor(pro => pro.PrecoCusto).GreaterThan(0);
            RuleFor(pro => pro.PrecoVenda).GreaterThan(0);
        }
    }
}
