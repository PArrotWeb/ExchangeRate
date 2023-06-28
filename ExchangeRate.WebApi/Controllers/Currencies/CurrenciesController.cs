using ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.WebApi.Controllers.Currencies;

public sealed class CurrenciesController : BaseController
{

	public CurrenciesController(ISender mediator) : base(mediator)
	{
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<CurrenciesVm>> Get([FromQuery] string country, CancellationToken cancellationToken)
	{
		var query = new GetCurrenciesQuery
		{
			Country = country.Trim().ToUpper()
		};
		var result = await mediator.Send(query, cancellationToken);
		return Ok(result);
	}
}