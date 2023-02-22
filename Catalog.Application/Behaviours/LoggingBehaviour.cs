using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

	public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
	{
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	/// <inheritdoc />
	public async Task<TResponse> Handle(TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		_logger.LogInformation("----- Handling command {CommandName} ({@Command})",
			request.GetGenericTypeName(),
			request.GetInJson());

		var response = await next();

		_logger.LogInformation("----- Command {CommandName} handled - response: {@Response}",
			request.GetGenericTypeName(),
			response?.GetInJson());

		return response;
	}
}