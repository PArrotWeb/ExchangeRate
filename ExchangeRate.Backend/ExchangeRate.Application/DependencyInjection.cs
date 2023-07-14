using System.Reflection;
using ExchangeRate.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRate.Application;

/// <summary>
/// Dependency injection for application layer
/// </summary>
public static class DependencyInjection
{
	/// <summary>
	/// Add application layer
	/// </summary>
	/// <param name="services"></param>
	/// <returns></returns>
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		// add mediatr
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

		// add fluent validation
		services.AddValidatorsFromAssemblies(new[] {Assembly.GetExecutingAssembly()});
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

		return services;
	}
}