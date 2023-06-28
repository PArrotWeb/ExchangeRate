using AutoMapper;
using ExchangeRate.Application.Common.Mappings;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCurrencies;

public sealed record CurrencyNameDto : IMapWith<Currency>
{
	public string CharCode { get; init; } = null!;

	#region IMapWith<Currency> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Currency, CurrencyNameDto>();
	}
	#endregion

}