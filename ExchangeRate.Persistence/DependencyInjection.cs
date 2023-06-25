using ExchangeRate.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRate.Persistence;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistence(this IServiceCollection services)
	{
		services.AddSingleton<ICentralBankRepository, CentralBankRepository>();
		return services;
	}
}