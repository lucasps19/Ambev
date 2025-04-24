using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;

        public UpdateSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<UpdateSaleResponse> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var existing = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existing == null) throw new KeyNotFoundException("Venda não encontrada.");

            existing.SaleNumber = request.SaleNumber;
            existing.CustomerId = request.CustomerId;
            existing.Branch = request.Branch;
            existing.Items.Clear();

            foreach (var item in request.Items)
            {
                existing.AddItem(new SaleItem
                {
                    Id = Guid.NewGuid(),
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }

            await _saleRepository.UpdateAsync(existing, cancellationToken);

            return new UpdateSaleResponse
            {
                Id = existing.Id,
                Total = existing.TotalAmount,
                Discount = existing.Items.Sum(i => i.Discount)
            };
        }
    }
}
