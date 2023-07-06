using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;

public sealed record GetCurrenciesQuery : IRequest<CurrenciesVm>
{
	public string Country { get; init; } = null!;
}