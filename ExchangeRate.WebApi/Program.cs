using System.Reflection;
using ExchangeRate.Application;
using ExchangeRate.Application.Common.Mappings;
using ExchangeRate.Application.Interfaces;
using ExchangeRate.Persistence;

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
	services.AddSwaggerGen();

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
	app.UseSwagger();
	app.UseSwaggerUI();

	app.UseHttpsRedirection();

	app.MapControllers();

	app.UseCors("AllowAll");
}