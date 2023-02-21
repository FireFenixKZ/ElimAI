using KDS.Primitives.FluentResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ISender Mediator =>
            HttpContext.RequestServices.GetRequiredService<ISender>() ?? throw new ArgumentNullException(nameof(ISender));

        public IActionResult HandleOperationResult<T>(Result<T> result)
        {
            if (result.IsFailed)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}
