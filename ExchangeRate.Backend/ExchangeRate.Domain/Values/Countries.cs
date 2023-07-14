namespace ExchangeRate.Domain.Values;

/// <summary>
/// Available countries in UPPER CASE.
/// </summary>
public static class Countries
{
	/// <summary>
	/// Russia country name in upper case.
	/// </summary>
	public const string Russia = "RUSSIA";

	/// <summary>
	/// Thailand country name in upper case.
	/// </summary>
	public const string Thailand = "THAILAND";

	/// <summary>
	/// List of all available countries for validation.
	/// All countries are in upper case.
	/// </summary>
	public static readonly List<string> All = new()
	{
		Russia,
		Thailand
	};
}