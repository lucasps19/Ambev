using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.SaleNumber)
                .NotEmpty().WithMessage("O número da venda é obrigatório.");

            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("A filial é obrigatória.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("O cliente é obrigatório.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("É necessário pelo menos um item na venda.")
                .ForEach(child => {
                    child.SetValidator(new SaleItemRequestValidator());
                });
        }
    }

    public class SaleItemRequestValidator : AbstractValidator<SaleItemRequest>
    {
        public SaleItemRequestValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Nome do produto é obrigatório.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.")
                .LessThanOrEqualTo(20).WithMessage("A quantidade não pode passar de 20 unidades.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Preço unitário deve ser maior que zero.");
        }
    }
}