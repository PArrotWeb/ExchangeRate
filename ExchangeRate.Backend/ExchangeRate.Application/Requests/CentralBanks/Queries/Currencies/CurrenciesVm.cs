namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;

public sealed record CurrenciesVm(IList<CurrencyDto> Currencies);