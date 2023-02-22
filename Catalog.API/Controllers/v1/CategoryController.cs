using Catalog.Application.Features.GetCategoryListQuery;
using KDS.Primitives.FluentResult;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers.v1
{
    [Route("api/v{apiVersion}/category")]
    [ApiController]
    [ApiVersion("v1")]
    public class CategoryController : BaseController
    {
        /// <summary>
        /// Get category list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(Result))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(ProblemDetails))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError, type: typeof(ProblemDetails))]
        public async Task<IActionResult> GetCategoryList()
        {
            var result = await Mediator.Send(new GetCategoryListQuery());
            return Ok(result);
        }

        /// <summary>
        /// Get category list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(Result))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(ProblemDetails))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.InternalServerError, type: typeof(ProblemDetails))]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var result = await Mediator.Send(new GetCategoryListQuery());
            return Ok(result);
        }
    }
}
