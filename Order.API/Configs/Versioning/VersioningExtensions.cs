using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Order.API.Configs.Versioning;

/// <summary>
/// extension settings up the versioning 
/// </summary>
public static class VersioningExtensions
{
	/// <summary>
	/// method adds versioning
	/// provides microsoft.versioning
	/// adds api versioning
	/// setup report api versions
	/// adds versioned api explorer
	/// setup group name format "v.VVV"
	/// setup substitute api version in url
	/// </summary>
	/// <param name = "services"> </param>
	/// <returns> </returns>
	public static IServiceCollection AddCustomizedVersioning(this IServiceCollection services)
	{
		services.AddApiVersioning(options =>
		{
			options.AssumeDefaultVersionWhenUnspecified = true;
			options.DefaultApiVersion = new ApiVersion(1, 0);
			options.ReportApiVersions = true;
		});

		services.AddVersionedApiExplorer(options =>
		{
			options.ApiVersionParameterSource = new UrlSegmentApiVersionReader();
		});

		return services;
	}
}