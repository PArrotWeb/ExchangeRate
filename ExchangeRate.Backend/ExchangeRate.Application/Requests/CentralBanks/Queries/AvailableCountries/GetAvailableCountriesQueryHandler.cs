using AutoMapper;
using ExchangeRate.Application.Interfaces;
using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCountries;

/// <summary>
/// Query handler for available countries request
/// </summary>
public sealed class GetAvailableCountriesQueryHandler : IRequestHandler<GetAvailableCountriesQuery, CountriesVm>
{

	private readonly ICentralBankRepository _centralBankRepository;
	private readonly IMapper _mapper;

	public GetAvailableCountriesQueryHandler(ICentralBankRepository centralBankRepository, IMapper mapper)
	{
		_centralBankRepository = centralBankRepository;
		_mapper = mapper;
	}

	#region IRequestHandler<GetAvailableCountriesQuery,CountriesVm> Members
	public async Task<CountriesVm> Handle(GetAvailableCountriesQuery request, CancellationToken cancellationToken)
	{
		// Get all available central banks
		var centralBanks = await _centralBankRepository.GetCentralBanksAsync(cancellationToken);

		// Select only countries and map them to CountryDto
		var countries = centralBanks.Select(x => _mapper.Map<CountryDto>(x)).ToList();

		// Return CountriesVm with list of countries
		return new CountriesVm(countries);
	}
	#endregion

}