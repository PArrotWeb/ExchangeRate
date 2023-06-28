using ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCurrencies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.WebApi.Controllers.AvailableCurrencies;

public sealed class AvailableCurrenciesController : BaseController
{

	public AvailableCurrenciesController(ISender mediator) : base(mediator)
	{
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<CurrencyNamesVm>> GetAvailableCurrencies([FromQuery] string country,
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