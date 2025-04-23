using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;

        public CreateSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<CreateSaleResponse> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                SaleNumber = request.SaleNumber,
                CustomerId = request.CustomerId,
                Branch = request.Branch,
                SaleDate = DateTime.UtcNow
            };

            foreach (var item in request.Items)
            {
                sale.AddItem(new SaleItem
                {
                    Id = Guid.NewGuid(),
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }

            await _saleRepository.CreateAsync(sale, cancellationToken);

            return new CreateSaleResponse
            {
                Id = sale.Id,
                Total = sale.TotalAmount,
                Discount = sale.Items.Sum(i => i.Discount),
                FinalAmount = sale.TotalAmount
            };
        }
    }
}