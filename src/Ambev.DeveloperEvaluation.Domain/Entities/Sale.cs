namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<SaleItem> Items { get; set; } = new();
        public decimal TotalAmount => CalculateTotalAmount();
        public bool IsCancelled { get; private set; } = false;
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        private decimal CalculateTotalAmount()
        {
            return Items.Sum(item => item.Total);
        }

        public void AddItem(SaleItem item)
        {
            var discount = 0m;

            var existingItem = Items.FirstOrDefault(x => x.Id == item.Id);

            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity + existingItem.Quantity;

                if (existingItem.Quantity > 20)
                    throw new InvalidOperationException("Máximo de 20 unidades por item permitido.");

                
                if (existingItem.Quantity >= 10)
                    discount = existingItem.UnitPrice * existingItem.Quantity * 0.20m;
                else if (existingItem.Quantity >= 4)
                    discount = existingItem.UnitPrice * existingItem.Quantity * 0.10m;

                item.Discount = discount;

                return;
            }

            if (item.Quantity > 20)
                throw new InvalidOperationException("Máximo de 20 unidades por item permitido.");

            if (item.Quantity >= 10)
                discount = item.UnitPrice * item.Quantity * 0.20m;
            else if (item.Quantity >= 4)
                discount = item.UnitPrice * item.Quantity * 0.10m;

            item.Discount = discount;

            Items.Add(item);
        }

        public void Cancel()
        {
            IsCancelled = true;
        }
    }
}
