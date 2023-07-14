using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCountries;

/// <summary>
/// Query for available countries request
/// </summary>
public sealed record GetAvailableCountriesQuery : IRequest<CountriesVm>;