using KDS.Primitives.FluentResult;
using MediatR;
using Order.Application.DTO;

namespace Order.Application.Features.GetOrderListQuery
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, Result<List<OrderDTO>>>
    {
        public async Task<Result<List<OrderDTO>>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return Result.Success(new List<OrderDTO>());
        }
    }
}
