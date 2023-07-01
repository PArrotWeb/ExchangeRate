using System.ComponentModel.DataAnnotations;
using ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCurrencies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.WebApi.Controllers.AvailableCurrencies;

public sealed class AvailableCurrenciesController : BaseController
{

	public AvailableCurrenciesController(ISender mediator) : base(mediator)
	{
	}

	/// <summary>
	/// Get list of available currencies for specific country central bank
	/// </summary>
	/// <param name="country">One of available country</param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<CurrencyNamesVm>> GetAvailableCurrencies([FromQuery] [Required] string country,
		CancellationToken cancellationToken)
	{
		var query = new GetAvailableCurrenciesQuery
		{
			Country = country.Trim().ToUpper()
		};
		var result = await mediator.Send(query, cancellationToken);
		return Ok(result);
	}
}