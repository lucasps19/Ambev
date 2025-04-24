using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesQuery, List<GetAllSalesResponse>>
    {
        private readonly ISaleRepository _saleRepository;

        public GetAllSalesHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<GetAllSalesResponse>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.GetAllAsync(cancellationToken);

            return sales.Select(sale => new GetAllSalesResponse
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber,
                CustomerId = sale.CustomerId,
                Branch = sale.Branch,
                SaleDate = sale.SaleDate,
                Total = sale.TotalAmount,
                Discount = sale.Items.Sum(i => i.Discount),
                IsCancelled = sale.IsCancelled
            }).ToList();
        }
    }
}
