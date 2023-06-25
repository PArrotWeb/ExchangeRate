namespace ExchangeRate.Application.Requests;

public sealed record CurrenciesVm(IList<CurrencyDto> Currencies);