using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Common.Converter;

public static class CurrencyConverter
{
	private const int RoundDigits = 4;

	/// <summary>
	/// Convert value from one currency to another
	/// </summary>
	/// <param name="from"></param>
	/// <param name="to"></param>
	/// <param name="value"></param>
	/// <returns>Total amount rounded to 4 decimal places</returns>
	public static decimal Convert(Currency from, Currency to, decimal value)
	{
		var fromRate = from.Value / from.Nominal;
		var toRate = to.Value / to.Nominal;

		var result = value * fromRate / toRate;
		result = Math.Round(result, RoundDigits);

		return result;
	}
}