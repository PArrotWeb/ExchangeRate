using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Convert;

/// <summary>
/// Query for convert request
/// </summary>
public sealed record GetConvertedCurrencyQuery : IRequest<ConvertDto>
{
	/// <summary>
	/// Country name of central bank, by which currency rate will be converted
	/// </summary>
	public string Country { get; init; } = null!;

	/// <summary>
	/// Amount of currency to convert
	/// </summary>
	public decimal Amount { get; init; }

	/// <summary>
	/// Char code of currency (FROM) to convert
	/// </summary>
	public string FromCharCode { get; init; } = null!;

	/// <summary>
	/// Char code of currency (TO) to convert
	/// </summary>
	public string ToCharCode { get; init; } = null!;
}