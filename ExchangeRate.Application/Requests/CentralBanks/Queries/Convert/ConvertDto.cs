namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Convert;

public sealed record ConvertDto
{
	public decimal Amount { get; init; }
}