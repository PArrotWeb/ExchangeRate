using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCurrencies;

public sealed record GetAvailableCurrenciesQuery : IRequest<CurrencyNamesVm>
{
	public string Country { get; init; } = null!;
}