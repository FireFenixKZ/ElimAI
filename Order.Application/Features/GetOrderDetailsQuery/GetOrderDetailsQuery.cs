using KDS.Primitives.FluentResult;
using MediatR;
using Order.Application.DTO;

namespace Order.Application.Features.GetOrderDetailsQuery
{
    public class GetOrderDetailsQuery : IRequest<Result<OrderDTO>>
    {
    }
}
