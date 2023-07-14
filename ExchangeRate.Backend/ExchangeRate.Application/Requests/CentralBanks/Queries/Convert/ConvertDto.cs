namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Convert;

/// <summary>
/// Data transfer object for convert request
/// </summary>
public sealed record ConvertDto
{
	/// <summary>
	/// Result of convert
	/// </summary>
	public decimal Amount { get; init; }
}