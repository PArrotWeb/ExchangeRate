using ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCountries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.WebApi.Controllers.AvailableCountries;

/// <summary>
/// Controller for available countries
/// </summary>
public sealed class AvailableCountriesController : BaseController
{

	public AvailableCountriesController(ISender mediator) : base(mediator)
	{
	}

	/// <summary>
	/// Get list of available countries
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns>List of available countries</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<CountriesVm>> GetAvailableCountries(CancellationToken cancellationToken)
	{
		var query = new GetAvailableCountriesQuery();
		var result = await mediator.Send(query, cancellationToken);
		return Ok(result);
	}
}