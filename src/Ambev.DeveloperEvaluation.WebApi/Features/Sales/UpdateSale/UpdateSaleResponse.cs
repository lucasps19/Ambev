namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleResponse
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
    }
}
