namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleResponse
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public string Branch { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public bool IsCancelled { get; set; }
        public List<GetSaleItemResponse> Items { get; set; } = new();
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
    }
}
