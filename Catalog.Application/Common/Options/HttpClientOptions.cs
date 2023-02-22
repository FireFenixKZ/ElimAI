namespace Catalog.Application.Common.Options;

public class HttpClientOptions
{
	public const string SectionName = nameof(HttpClientOptions);
	
	public string Origin { get; set; } = String.Empty;
	public string Endpoint { get; set; } = String.Empty;
	public int TimeoutInSeconds { get; set; } = 30;
}