namespace ExchangeRate.Domain.Entities;

/// <summary>
/// Model for central bank data
/// </summary>
public class CentralBank
{
	/// <summary>
	/// Country name where central bank is located
	/// </summary>
	public string Country { get; init; } = null!;

	/// <summary>
	/// Date and time when central bank data was updated
	/// </summary>
	public DateTime? LastUpdated { get; set; }

	/// <summary>
	/// List of currencies rates for this central bank
	/// </summary>
	public List<Currency> Currencies { get; init; } = null!;
}