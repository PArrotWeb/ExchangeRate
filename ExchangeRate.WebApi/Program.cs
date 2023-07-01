using System.Reflection;
using ExchangeRate.Application;
using ExchangeRate.Application.Common.Mappings;
using ExchangeRate.Application.Interfaces;
using ExchangeRate.Persistence;
using ExchangeRate.WebApi.Middleware.CustomExceptionMiddleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);

var app = builder.Build();
ConfigureApp();
app.Run();

void ConfigureServices(IServiceCollection services)
{
	services.AddApplication();
	services.AddPersistence();

	services.AddEndpointsApiExplorer();

	if (builder.Environment.IsDevelopment())
	{
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo
				{Title = "ExchangeRate.WebApi", Version = "v1"});
		});
	}

	services.AddControllers();

	// Add mapping
	builder.Services.AddAutoMapper(config =>
	{
		config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
		config.AddProfile(new AssemblyMappingProfile(typeof(ICentralBankRepository).Assembly));
	});

	// Add CORS
	builder.Services.AddCors(options =>
	{
		options.AddPolicy("AllowAll", policy =>
		{
			policy.AllowAnyHeader();
			policy.AllowAnyMethod();
			policy.AllowAnyOrigin();
		});
	});
}

void ConfigureApp()
{
	if (app.Environment.IsDevelopment())
	{
		app.UseDeveloperExceptionPage();
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseCustomExceptionHandler();

	app.UseRouting();

	app.UseHttpsRedirection();

	app.UseCors("AllowAll");

	app.MapControllers();

}