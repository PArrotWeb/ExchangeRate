using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Common.Converter;

/// <summary>
/// Static class for convert currency
/// </summary>
public static class CurrencyConverter
{
	/// <summary>
	/// Number of decimal places to round
	/// </summary>
	private const int RoundDigits = 4;

	/// <summary>
	/// Convert value from one currency to another
	/// </summary>
	/// <param name="from">Instance of Currency</param>
	/// <param name="to">Instance of Currency</param>
	/// <param name="value">Value of convert with rounding</param>
	/// <returns>Total amount rounded to 4 decimal places</returns>
	public static decimal Convert(Currency from, Currency to, decimal value)
	{
		// Calculate the ratio of the currencies (Reduction to a single nominal)
		var fromRate = from.Value / from.Nominal;
		var toRate = to.Value / to.Nominal;

		// Calculate result amount
		var result = value * fromRate / toRate;

		// Round result
		result = Math.Round(result, RoundDigits);

		return result;
	}
}