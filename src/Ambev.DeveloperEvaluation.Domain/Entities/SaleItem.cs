namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        public decimal Total => (UnitPrice * Quantity) - Discount;

        public Guid SaleId { get; set; }
        public Sale Sale { get; set; } = null!;
    }
}
