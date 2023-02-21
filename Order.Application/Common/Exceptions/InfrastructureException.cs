namespace Order.Application.Common.Exceptions;

/// <summary>
/// presents exceptions occured on infrastructure level
/// </summary>
public class InfrastructureException : Exception
{
	public InfrastructureException(string message)
		: base(message) { }
	
	public InfrastructureException(string message, Exception ex)
		: base(message, ex) { }
}