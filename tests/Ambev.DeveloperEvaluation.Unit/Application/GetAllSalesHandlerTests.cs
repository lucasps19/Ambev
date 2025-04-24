using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class GetAllSalesHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly GetAllSalesHandler _handler;

        public GetAllSalesHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _handler = new GetAllSalesHandler(_saleRepository);
        }

        [Fact]
        public async Task Should_Return_List_Of_Sales()
        {
            var sales = new List<Sale>
            {
                new Sale
                {
                    Id = Guid.NewGuid(),
                    SaleNumber = "S001",
                    CustomerId = Guid.NewGuid(),
                    Branch = "Filial A",
                    SaleDate = DateTime.UtcNow,
                    Items = new List<SaleItem>
                    {
                        new SaleItem { ProductName = "Produto A", Quantity = 5, UnitPrice = 10, Discount = 5 }
                    }
                },
                new Sale
                {
                    Id = Guid.NewGuid(),
                    SaleNumber = "S002",
                    CustomerId = Guid.NewGuid(),
                    Branch = "Filial B",
                    SaleDate = DateTime.UtcNow,
                    Items = new List<SaleItem>
                    {
                        new SaleItem { ProductName = "Produto B", Quantity = 3, UnitPrice = 20, Discount = 0 }
                    }
                }
            };

            _saleRepository.GetAllAsync(Arg.Any<CancellationToken>()).Returns(sales);

            var result = await _handler.Handle(new GetAllSalesQuery(), CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }
    }
}
