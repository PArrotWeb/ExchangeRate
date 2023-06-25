﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRate.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
		return services;
	}
}