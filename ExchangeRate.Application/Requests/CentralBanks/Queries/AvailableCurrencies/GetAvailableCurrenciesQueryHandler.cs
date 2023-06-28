using AutoMapper;
using ExchangeRate.Application.Interfaces;
using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.AvailableCurrencies;

public sealed class GetAvailableCurrenciesQueryHandler : IRequestHandler<GetAvailableCurrenciesQuery, CurrencyNamesVm>
{
	private readonly ICentralBankRepository _centralBankRepository;
	private readonly IMapper _mapper;

	public GetAvailableCurrenciesQueryHandler(ICentralBankRepository centralBankRepository, IMapper mapper)
	{
		_centralBankRepository = centralBankRepository;
		_mapper = mapper;
	}

	#region IRequestHandler<GetAvailableCurrenciesQuery,CurrencyNamesVm> Members
	public async Task<CurrencyNamesVm> Handle(GetAvailableCurrenciesQuery request, CancellationToken cancellationToken)
	{
		var centralBank = await _centralBankRepository.GetCentralBankAsync(request.Country, cancellationToken);
		var currencyNames = centralBank.Currencies.Select(x => _mapper.Map<CurrencyNameDto>(x)).ToList();
		return new CurrencyNamesVm(currencyNames);
	}
	#endregion

}