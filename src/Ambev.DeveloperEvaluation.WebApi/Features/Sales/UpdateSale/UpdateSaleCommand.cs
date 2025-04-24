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
    }

    public class UpdateSaleItemCommand
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
