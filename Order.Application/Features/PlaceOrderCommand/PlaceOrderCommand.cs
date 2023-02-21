using KDS.Primitives.FluentResult;
using MediatR;
using Order.Application.DTO;

namespace Order.Application.Features.PlaceOrderCommand
{
    public class PlaceOrderCommand : IRequest<Result>
    {
        public OrderDTO OrderDto { get; set; }
    }
}
