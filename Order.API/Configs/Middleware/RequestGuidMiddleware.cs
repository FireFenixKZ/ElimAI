using CTeleport.DistanceCalculator.Api.Common.Constants;

namespace Order.API.Configs.Middleware;

/// <summary>
/// middleware sets id to each request
/// </summary>
public class RequestGuidMiddleware
{
	private readonly RequestDelegate _next;

	/// <summary>
	/// create <see cref="RequestGuidMiddleware"/> instance
	/// </summary>
	/// <param name="next"></param>
	public RequestGuidMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	/// <summary>
	/// use middleware
	/// </summary>
	/// <param name="context"></param>
	public async Task InvokeAsync(HttpContext context)
	{
		var requestId = context.Request.Headers[HeaderConstant.RequestId];

		context.Request.Headers[HeaderConstant.RequestId] =
			String.IsNullOrEmpty(requestId) ? Guid.NewGuid().ToString() : requestId;

		await _next(context);
	}
}