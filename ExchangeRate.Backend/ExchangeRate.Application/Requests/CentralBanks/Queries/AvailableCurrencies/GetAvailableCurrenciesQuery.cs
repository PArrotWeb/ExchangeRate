using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCurrencies;

/// <summary>
/// Query for available currencies request
/// </summary>
public sealed record GetAvailableCurrenciesQuery : IRequest<CurrencyNamesVm>
{
	/// <summary>
	/// Country name of central bank for which currencies will be returned
	/// </summary>
	public string Country { get; init; } = null!;
}