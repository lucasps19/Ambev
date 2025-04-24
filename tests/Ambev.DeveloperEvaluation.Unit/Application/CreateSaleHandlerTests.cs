using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Bogus;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _handler = new CreateSaleHandler(_saleRepository);
        }

        [Fact]
        public async Task Should_Create_Sale_With_Discounts()
        {
            var faker = new Faker();
            var command = new CreateSaleCommand
            {
                SaleNumber = faker.Random.Guid().ToString(),
                CustomerId = Guid.NewGuid(),
                Branch = faker.Company.CompanyName(),
                Items = new List<SaleItemCommand>
                {
                    new SaleItemCommand { ProductName = "Produto A", Quantity = 5, UnitPrice = 100 },
                    new SaleItemCommand { ProductName = "Produto B", Quantity = 12, UnitPrice = 50 }
                }
            };

            _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
                .Returns(callInfo => callInfo.Arg<Sale>());

            var response = await _handler.Handle(command, CancellationToken.None);

            response.Should().NotBeNull();
            response.Total.Should().BeGreaterThan(0);
            response.Discount.Should().BeGreaterThan(0);
        }
    }
}
