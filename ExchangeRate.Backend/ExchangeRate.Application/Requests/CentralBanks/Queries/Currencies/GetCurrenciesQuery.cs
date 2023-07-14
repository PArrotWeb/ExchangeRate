using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;

/// <summary>
/// Query for get currencies request
/// </summary>
public sealed record GetCurrenciesQuery : IRequest<CurrenciesVm>
{
	/// <summary>
	/// Country name of central bank for which currency rates will be returned
	/// </summary>
	public string Country { get; init; } = null!;
}