using KDS.Primitives.FluentResult;
using MediatR;

namespace Order.Application.Features.PlaceOrderCommand
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Result>
    {
        public async Task<Result> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            return Result.Success();
        }
    }
}
