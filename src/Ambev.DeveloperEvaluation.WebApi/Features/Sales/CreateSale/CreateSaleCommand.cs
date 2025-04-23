using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResponse>
    {
        public string SaleNumber { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<SaleItemCommand> Items { get; set; } = new();
    }

    public class SaleItemCommand
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
