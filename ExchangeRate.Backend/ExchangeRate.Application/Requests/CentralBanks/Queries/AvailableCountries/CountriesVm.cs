namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCountries;

/// <summary>
/// View model for available countries
/// </summary>
/// <param name="Countries">List of CountryDto </param>
public sealed record CountriesVm(IList<CountryDto> Countries);