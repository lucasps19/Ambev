using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.SaleNumber)
                .NotEmpty().WithMessage("O número da venda é obrigatório.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("O cliente é obrigatório.");

            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("A filial é obrigatória.");

            RuleForEach(x => x.Items).SetValidator(new UpdateSaleItemRequestValidator());
        }
    }

    public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
    {
        public UpdateSaleItemRequestValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Nome do produto é obrigatório.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.")
                .LessThanOrEqualTo(20).WithMessage("Quantidade não pode passar de 20 unidades.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Preço unitário deve ser maior que zero.");
        }
    }
}
