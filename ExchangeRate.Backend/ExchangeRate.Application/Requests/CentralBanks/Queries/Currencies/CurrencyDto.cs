using AutoMapper;
using ExchangeRate.Application.Common.Mappings;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;

/// <summary>
/// Data transfer object for currency
/// </summary>
public sealed record CurrencyDto : IMapWith<Currency>
{
	/// <summary>
	/// Char code of currency
	/// </summary>
	public string CharCode { get; init; } = null!;

	/// <summary>
	/// Nominal of currency
	/// </summary>
	public decimal Nominal { get; init; }

	/// <summary>
	/// Currency rate
	/// </summary>
	public decimal Value { get; init; }

	#region IMapWith<Currency> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Currency, CurrencyDto>();
	}
	#endregion

}