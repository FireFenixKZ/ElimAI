using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CTeleport.DistanceCalculator.Api.Common.Extensions;

/// <summary>
/// extension for exceptions
/// </summary>
public static class ExceptionExtensions
{
	/// <summary>
	/// generates <see cref="ProblemDetails"/> instance
	/// </summary>
	public static ProblemDetails GenerateProblemDetails(this Exception ex,
		HttpContext context,
		HttpStatusCode code,
		string message)
	{
		context.Response.StatusCode = (int)code;
		context.Response.ContentType = "application/json";

		ProblemDetails problemDetails = new() { Status = (int)code, Title = message, Detail = ex.Message, };

		return problemDetails;
	}

	/// <summary>
	/// Returns inner exception messages in one string
	/// </summary>
	/// <param name="ex"></param>
	/// <param name="errors"></param>
	/// <returns></returns>
	public static string GetInnerException(this Exception? ex, StringBuilder? errors)
	{
		errors ??= new StringBuilder();

		while (ex is not null)
		{
			errors.Append(ex.Message + ". ");
			ex = ex.InnerException;
		}

		return errors.ToString();
	}
}