namespace Order.Application.Common.Exceptions;

/// <summary>
/// presents exceptions on domain level
/// </summary>
public class DomainException : Exception
{
	public DomainException(string message)
		: base(message) { }
}