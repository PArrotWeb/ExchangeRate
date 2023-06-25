namespace ExchangeRate.Application.Requests;

public sealed record ConvertDto
{
	public decimal Amount { get; init; }
}