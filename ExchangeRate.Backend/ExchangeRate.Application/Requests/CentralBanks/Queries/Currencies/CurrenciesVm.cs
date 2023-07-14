namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;

/// <summary>
/// View model for CurrencyDto
/// </summary>
/// <param name="Currencies"></param>
public sealed record CurrenciesVm(IList<CurrencyDto> Currencies);