using ExchangeRate.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRate.Persistence;

/// <summary>
/// Dependency injection for persistence layer
/// </summary>
public static class DependencyInjection
{
	/// <summary>
	/// Add persistence layer
	/// </summary>
	/// <param name="services"></param>
	/// <returns></returns>
	public static IServiceCollection AddPersistence(this IServiceCollection services)
	{
		// add central bank repositories
		services.AddSingleton<ICentralBankRepository, CentralBankRepository>();

		return services;
	}
}