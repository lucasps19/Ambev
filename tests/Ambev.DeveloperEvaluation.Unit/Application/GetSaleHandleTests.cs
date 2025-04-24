using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class GetSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly GetSaleHandler _handler;

        public GetSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _handler = new GetSaleHandler(_saleRepository);
        }

        [Fact]
        public async Task Should_Return_Sale_When_Found()
        {
            var saleId = Guid.NewGuid();
            var sale = new Sale
            {
                Id = saleId,
                SaleNumber = "ABC123",
                Branch = "Filial A",
                CustomerId = Guid.NewGuid(),
                SaleDate = DateTime.UtcNow,
                Items = new List<SaleItem>
                {
                    new SaleItem { ProductName = "Produto A", Quantity = 5, UnitPrice = 100, Discount = 50 }
                }
            };

            _saleRepository.GetByIdAsync(saleId, Arg.Any<CancellationToken>()).Returns(sale);

            var result = await _handler.Handle(new GetSaleQuery { Id = saleId }, CancellationToken.None);

            result.Should().NotBeNull();
            result.Total.Should().BeGreaterThan(0);
            result.Items.Should().HaveCount(1);
        }

        [Fact]
        public async Task Should_Return_Null_When_Sale_Not_Found()
        {
            var saleId = Guid.NewGuid();
            _saleRepository.GetByIdAsync(saleId, Arg.Any<CancellationToken>()).Returns((Sale?)null);

            var result = await _handler.Handle(new GetSaleQuery { Id = saleId }, CancellationToken.None);

            result.Should().BeNull();
        }
    }
}
