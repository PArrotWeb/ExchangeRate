using System.ComponentModel.DataAnnotations;
using ExchangeRate.Domain.Values;

namespace ExchangeRate.WebApi.Controllers.Convert;

public sealed class ConvertQuery
{
	/// <summary>
	/// One of available country. Default is Russia
	/// </summary>
	public string Country { get; init; } = Countries.Russia;

	/// <summary>
	/// Amount of currency to convert. From 0.01 to (10^27).(10^4)
	/// </summary>
	[Required]
	public decimal Amount { get; init; }

	/// <summary>
	/// Currency char code to convert from (e.g. EUR). ISO 4217
	/// </summary>
	[Required]
	public string From { get; init; } = null!;

	/// <summary>
	/// Currency char code to convert to (e.g. USD). ISO 4217
	/// </summary>
	[Required]
	public string To { get; init; } = null!;
}