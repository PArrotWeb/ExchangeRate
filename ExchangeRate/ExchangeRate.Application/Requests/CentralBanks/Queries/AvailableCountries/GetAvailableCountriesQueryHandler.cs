using AutoMapper;
using ExchangeRate.Application.Interfaces;
using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCountries;

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
		var centralBanks = await _centralBankRepository.GetCentralBanksAsync(cancellationToken);
		var countries = centralBanks.Select(x => _mapper.Map<CountryDto>(x)).ToList();
		return new CountriesVm(countries);
	}
	#endregion

}