using ExchangeRate.Domain.Entities;

namespace ExchangeRate.WebApi.Controllers.Convert;

public sealed class ConvertQuery
{
	public string Country { get; init; } = Countries.Russia;
	public decimal Amount { get; init; }
	public string From { get; init; } = null!;
	public string To { get; init; } = null!;
}