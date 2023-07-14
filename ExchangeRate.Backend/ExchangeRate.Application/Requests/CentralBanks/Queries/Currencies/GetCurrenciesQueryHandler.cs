using AutoMapper;
using ExchangeRate.Application.Interfaces;
using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;

/// <summary>
/// Query handler for get currencies request
/// </summary>
public sealed class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, CurrenciesVm>
{
	private readonly ICentralBankRepository _centralBankRepository;
	private readonly IMapper _mapper;

	public GetCurrenciesQueryHandler(ICentralBankRepository centralBankRepository, IMapper mapper)
	{
		_centralBankRepository = centralBankRepository;
		_mapper = mapper;
	}

	#region IRequestHandler<GetCurrenciesQuery,CurrenciesVm> Members
	public async Task<CurrenciesVm> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
	{
		// Get central bank by country name
		var centralBank = await _centralBankRepository.GetCentralBankAsync(request.Country, cancellationToken);

		// Select only currencies and map them to CurrencyDto
		var currencies = centralBank.Currencies.Select(x => _mapper.Map<CurrencyDto>(x)).ToList();

		// Return CurrenciesVm with list of currencies
		return new CurrenciesVm(currencies);
	}
	#endregion

}