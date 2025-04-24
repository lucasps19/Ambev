namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales
{
    public class GetAllSalesResponse
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public string Branch { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public bool IsCancelled { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
    }
}