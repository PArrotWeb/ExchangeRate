using MediatR;

namespace ExchangeRate.Application.Requests.Russia.Queries.GetRussiaCurrencies;

public sealed record GetRussiaCurrenciesQuery : IRequest<CurrenciesVm>;