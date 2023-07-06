using AutoMapper;
using ExchangeRate.Application.Common.Mappings;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;

public sealed record CurrencyDto : IMapWith<Currency>
{
	public string CharCode { get; init; } = null!;

	public decimal Nominal { get; init; }

	public decimal Value { get; init; }

	#region IMapWith<Currency> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Currency, CurrencyDto>();
	}
	#endregion

}