using AutoMapper;
using ExchangeRate.Application.Interfaces;
using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;

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
		var centralBank = await _centralBankRepository.GetCentralBankAsync(request.Country, cancellationToken);
		var currencies = centralBank.Currencies.Select(x => _mapper.Map<CurrencyDto>(x)).ToList();
		return new CurrenciesVm(currencies);
	}
	#endregion

}