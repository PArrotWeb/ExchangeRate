using AutoMapper;
using ExchangeRate.Application.Common.Mappings;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCurrencies;

/// <summary>
/// Data transfer object for available currencies
/// </summary>
public sealed record CurrencyNameDto : IMapWith<Currency>
{
	/// <summary>
	/// Char code of currency
	/// </summary>
	public string CharCode { get; init; } = null!;

	#region IMapWith<Currency> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Currency, CurrencyNameDto>();
	}
	#endregion

}