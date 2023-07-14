namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCurrencies;

/// <summary>
/// View model for available currencies
/// </summary>
/// <param name="CurrenciesNames">List of CurrencyNameDto</param>
public sealed record CurrencyNamesVm(IList<CurrencyNameDto> CurrenciesNames);