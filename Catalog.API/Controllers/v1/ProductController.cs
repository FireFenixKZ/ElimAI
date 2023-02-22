using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.v1
{
    [Route("api/v{apiVersion}/product")]
    [ApiController]
    [ApiVersion("v1")]
    public class ProductController : ControllerBase
    {
    }
}
