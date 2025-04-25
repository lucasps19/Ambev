using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleCommand : IRequest<UpdateSaleResponse>
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<UpdateSaleItemCommand> Items { get; set; } = new();

        public void Update(Domain.Entities.Sale sale)
        {
            sale.SaleNumber = SaleNumber;
            sale.CustomerId = CustomerId;
            sale.Branch = Branch;

            sale.Items.RemoveAll(c => true);

            foreach (var item in Items)
            {
                sale.AddItem(new SaleItem
                {
                    Id = Guid.NewGuid(),
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                });
            }
        }
    }

    public class UpdateSaleItemCommand
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
