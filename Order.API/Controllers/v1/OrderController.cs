using KDS.Primitives.FluentResult;
using Microsoft.AspNetCore.Mvc;
using Order.Application.DTO;
using Order.Application.Features.GetOrderListQuery;
using System.Net;

namespace Order.API.Controllers.v1
{
    [Route("api/v{apiVersion}/order")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrderController : BaseController
    {
        /// <summary>
        /// Get order list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(Result<OrderDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(ProblemDetails))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError, type: typeof(ProblemDetails))]
        public async Task<IActionResult> GetOrders()
        {
            var result = await Mediator.Send(new GetOrderListQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("place")]
        public async Task<IActionResult> PlaceOrder()
        {
            var result = await Mediator.Send(PlaceOrderCommand());
            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrdersDetails(int orderId)
        {
            var result = await Mediator.Send(GetOrderDetailsQuery(orderId));
            return Ok(result);
        }
    }
}
