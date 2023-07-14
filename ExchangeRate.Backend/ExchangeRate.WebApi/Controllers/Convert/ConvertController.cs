using ExchangeRate.Application.Requests.CentralBanks.Queries.Convert;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.WebApi.Controllers.Convert;

/// <summary>
/// Controller for currency convert
/// </summary>
public sealed class ConvertController : BaseController
{

	public ConvertController(ISender mediator) : base(mediator)
	{

	}

	/// <summary>
	/// Convert currency from one to another by one of available central bank
	/// </summary>
	/// <param name="convertQuery"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ConvertDto>> Convert([FromQuery] ConvertQuery convertQuery,
		CancellationToken cancellationToken)
	{
		var query = new GetConvertedCurrencyQuery
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