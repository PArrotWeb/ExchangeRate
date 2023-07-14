using AutoMapper;
using ExchangeRate.Application.Common.Mappings;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCountries;

/// <summary>
/// Data transfer object for available countries
/// </summary>
public sealed record CountryDto : IMapWith<CentralBank>
{
	/// <summary>
	/// Name of country
	/// </summary>
	public string Name { get; init; } = null!;

	#region IMapWith<CentralBank> Members
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CentralBank, CountryDto>()
			.ForMember(x => x.Name, opt => opt.MapFrom(x => x.Country));
	}
	#endregion

}