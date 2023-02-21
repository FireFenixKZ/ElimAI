using KDS.Primitives.FluentResult;
using MediatR;
using Order.Application.DTO;

namespace Order.Application.Features.GetOrderListQuery
{
    public class GetOrderListQuery : IRequest<Result<List<OrderDTO>>>
    {
    }
}
