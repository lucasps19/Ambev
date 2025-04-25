using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact]
        public void Should_Apply_10_Percent_Discount_When_Quantity_Is_4_To_9()
        {
            var sale = new Sale();

            sale.AddItem(new SaleItem
            {
                Id = Guid.NewGuid(),
                ProductName = "Produto X",
                Quantity = 5,
                UnitPrice = 100m
            });

            var item = sale.Items.First();
            item.Discount.Should().Be(50);
            sale.TotalAmount.Should().Be(450);
        }

        [Fact]
        public void Should_Apply_20_Percent_Discount_When_Quantity_Is_10_To_20()
        {
            var sale = new Sale();

            sale.AddItem(new SaleItem
            {
                Id = Guid.NewGuid(),
                ProductName = "Produto Y",
                Quantity = 10,
                UnitPrice = 50m
            });

            var item = sale.Items.First();
            item.Discount.Should().Be(100);
            sale.TotalAmount.Should().Be(400);
        }

        [Fact]
        public void Should_Throw_When_Quantity_Exceeds_20()
        {
            var sale = new Sale();

            Action act = () => sale.AddItem(new SaleItem
            {
                Id = Guid.NewGuid(),
                ProductName = "Produto Z",
                Quantity = 21,
                UnitPrice = 10m
            });

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Máximo de 20 unidades por item permitido.");
        }

        [Fact]
        public void Should_Accumulate_Quantities_For_Same_Product()
        {
            var sale = new Sale();
            var id = Guid.NewGuid();

            sale.AddItem(new SaleItem
            {
                Id = id,
                ProductName = "Produto W",
                Quantity = 10,
                UnitPrice = 20m
            });

            sale.AddItem(new SaleItem
            {
                Id = id,
                ProductName = "Produto W",
                Quantity = 5,
                UnitPrice = 20m
            });

            var item = sale.Items.First();
            item.Quantity.Should().Be(15);
        }
    }
}
