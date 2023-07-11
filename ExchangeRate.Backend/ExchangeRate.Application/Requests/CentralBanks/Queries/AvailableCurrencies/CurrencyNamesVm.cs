namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCurrencies;

public sealed record CurrencyNamesVm(IList<CurrencyNameDto> CurrenciesNames);