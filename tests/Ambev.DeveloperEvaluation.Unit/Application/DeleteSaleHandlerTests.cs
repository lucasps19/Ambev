using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class DeleteSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly DeleteSaleHandler _handler;

        public DeleteSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _handler = new DeleteSaleHandler(_saleRepository);
        }

        [Fact]
        public async Task Should_Delete_Sale_When_Found()
        {
            var saleId = Guid.NewGuid();
            _saleRepository.DeleteAsync(saleId, Arg.Any<CancellationToken>()).Returns(true);

            var command = new DeleteSaleCommand { Id = saleId };

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task Should_Return_False_When_Sale_Not_Found()
        {
            var saleId = Guid.NewGuid();
            _saleRepository.DeleteAsync(saleId, Arg.Any<CancellationToken>()).Returns(false);

            var command = new DeleteSaleCommand { Id = saleId };

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().BeFalse();
        }
    }
}
