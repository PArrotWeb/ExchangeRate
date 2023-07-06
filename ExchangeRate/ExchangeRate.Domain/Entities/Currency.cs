namespace ExchangeRate.Domain.Entities;

/// <summary>
/// Model for currency data. Includes name, char code, num code, nominal and value.
/// </summary>
public class Currency
{
	/// <summary>
	/// Name of currency from central bank
	/// </summary>
	public string Name { get; set; } = null!;

	/// <summary>
	/// Char code of currency
	/// </summary>
	public string CharCode { get; set; } = null!;

	/// <summary>
	/// Num code of currency. Can be null
	/// </summary>
	public short? NumCode { get; set; }

	/// <summary>
	/// Nominal of currency (factor)
	/// </summary>
	public short Nominal { get; set; } = 1;

	/// <summary>
	/// Value of currency in relation to central bank currency
	/// </summary>
	public decimal Value { get; set; }
}