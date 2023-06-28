using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCountries;

public sealed record GetAvailableCountriesQuery : IRequest<CountriesVm>;