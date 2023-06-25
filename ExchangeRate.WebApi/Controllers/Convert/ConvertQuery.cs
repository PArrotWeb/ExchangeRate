namespace ExchangeRate.WebApi.Controllers.Convert;

public sealed record ConvertQuery
{
	public string Country { get; init; } = null!;
	public decimal Amount { get; init; }
	public string From { get; init; } = null!;
	public string To { get; init; } = null!;
}