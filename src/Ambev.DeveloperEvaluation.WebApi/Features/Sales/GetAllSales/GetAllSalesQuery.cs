using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales
{
    public class GetAllSalesQuery : IRequest<List<GetAllSalesResponse>>
    {
    }
}
