using System.ComponentModel.DataAnnotations;
using ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.WebApi.Controllers.Currencies;

/// <summary>
/// Controller for currencies rates
/// </summary>
public sealed class CurrenciesController : BaseController
{

	public CurrenciesController(ISender mediator) : base(mediator)
	{
	}

	/// <summary>
	/// Get list of currencies rates by country
	/// </summary>
	/// <param name="country">One of the available countries</param>
	/// <param name="cancellationToken"></param>
	/// <returns>List of Currencies</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<CurrenciesVm>> Get([FromQuery] [Required] string country, CancellationToken
		cancellationToken)
	{
		var query = new GetCurrenciesQuery
		{
			Country = country.Trim().ToUpper()
		};
		var result = await mediator.Send(query, cancellationToken);
		return Ok(result);
	}
}