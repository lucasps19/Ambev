using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleHandler : IRequestHandler<GetSaleQuery, GetSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<GetSaleResponse> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (sale == null) return null!;

            return new GetSaleResponse
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber,
                CustomerId = sale.CustomerId,
                Branch = sale.Branch,
                SaleDate = sale.SaleDate,
                IsCancelled = sale.IsCancelled,
                Items = sale.Items.Select(i => new GetSaleItemResponse
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Discount = i.Discount,
                    Total = i.Total
                }).ToList(),
                Total = sale.TotalAmount,
                Discount = sale.Items.Sum(i => i.Discount)
            };
        }
    }
}
