using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using Bogus;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class UpdateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly UpdateSaleHandler _handler;

        public UpdateSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _handler = new UpdateSaleHandler(_saleRepository);
        }

        [Fact]
        public async Task Should_Update_Sale_With_New_Items_And_Discounts()
        {
            var saleId = Guid.NewGuid();
            var faker = new Faker();

            var existingSale = new Sale
            {
                Id = saleId,
                SaleNumber = "123",
                CustomerId = Guid.NewGuid(),
                Branch = "Antiga"
            };

            _saleRepository.GetByIdAsync(saleId, Arg.Any<CancellationToken>())
                .Returns(existingSale);

            _saleRepository.UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
                .Returns(callInfo => callInfo.Arg<Sale>());

            var command = new UpdateSaleCommand
            {
                Id = saleId,
                SaleNumber = "456",
                CustomerId = Guid.NewGuid(),
                Branch = "Nova Filial",
                Items = new List<UpdateSaleItemCommand>
                {
                    new UpdateSaleItemCommand { ProductName = "Produto A", Quantity = 4, UnitPrice = 100 },
                    new UpdateSaleItemCommand { ProductName = "Produto B", Quantity = 10, UnitPrice = 50 }
                }
            };

            var response = await _handler.Handle(command, CancellationToken.None);

            response.Should().NotBeNull();
            response.Total.Should().BeGreaterThan(0);
            response.Discount.Should().BeGreaterThan(0);
        }
    }
}
