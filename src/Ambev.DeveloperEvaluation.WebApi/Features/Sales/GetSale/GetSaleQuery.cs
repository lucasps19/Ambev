using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleQuery : IRequest<GetSaleResponse>
    {
        public Guid Id { get; set; }
    }
}
