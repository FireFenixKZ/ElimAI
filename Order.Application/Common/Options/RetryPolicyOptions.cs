namespace Order.Application.Common.Options;

public class RetryPolicyOptions
{
	public const string SectionName = nameof(RetryPolicyOptions);
	
	public int RetryCount { get; set; } = 3;
	public int[] DelaysInSeconds { get; set; } = { 1, 5, 10, };
	public int[] RetryStatusCodes { get; set; } = { 500, 408 };
}