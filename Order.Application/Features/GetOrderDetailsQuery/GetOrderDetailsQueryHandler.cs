using KDS.Primitives.FluentResult;
using MediatR;
using Order.Application.DTO;

namespace Order.Application.Features.GetOrderDetailsQuery
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, Result<OrderDTO>>
    {
        public async Task<Result<OrderDTO>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return Result.Success(new OrderDTO());
        }
    }
}
