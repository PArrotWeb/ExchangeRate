using ExchangeRate.Application.Requests;
using ExchangeRate.Application.Requests.Queries.ConvertRussiaCentralBank;
using ExchangeRate.Application.Requests.Russia.Queries.GetRussiaCurrencies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.WebApi.Controllers.Convert;

public sealed class CurrencyController : BaseController
{

	public CurrencyController(ISender mediator) : base(mediator)
	{

	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<CurrenciesVm>> GetRussiaCurrencies(CancellationToken cancellationToken)
	{
		var query = new GetRussiaCurrenciesQuery();
		var result = await mediator.Send(query, cancellationToken);
		return Ok(result);
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<ConvertDto>> Convert([FromQuery] ConvertQuery convertQuery, CancellationToken
		cancellationToken)
	{
		var query = new ConvertCentralBankQuery
		{
			Country = convertQuery.Country.Trim().ToUpper(),
			Amount = convertQuery.Amount,
			FromCharCode = convertQuery.From.Trim().ToUpper(),
			ToCharCode = convertQuery.To.Trim().ToUpper()
		};

		var result = await mediator.Send(query, cancellationToken);

		return Ok(result);
	}
}