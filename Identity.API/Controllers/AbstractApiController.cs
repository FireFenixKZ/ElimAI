using Identity.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbstractApiController : ControllerBase
    {
        protected ActionResult HandleOperationResult<T>(ServiceResponse<T> operationResult)
        {
            if (!operationResult.Success)
            {
                return BadRequest(operationResult);
            }

            return Ok(operationResult);
        }
    }
}
