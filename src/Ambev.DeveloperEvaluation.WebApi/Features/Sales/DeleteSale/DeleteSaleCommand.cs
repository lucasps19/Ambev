using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    public class DeleteSaleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
