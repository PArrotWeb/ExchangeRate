using AutoMapper;
using ExchangeRate.Application.Interfaces;
using ExchangeRate.Domain.Entities;
using MediatR;

namespace ExchangeRate.Application.Requests.Russia.Queries.GetRussiaCurrencies;

public sealed class GetRussiaCurrenciesQueryHandler : IRequestHandler<GetRussiaCurrenciesQuery, CurrenciesVm>
{
	private readonly ICentralBankRepository _centralBankRepository;
	private readonly IMapper _mapper;

	public GetRussiaCurrenciesQueryHandler(ICentralBankRepository centralBankRepository, IMapper mapper)
	{
		_centralBankRepository = centralBankRepository;
		_mapper = mapper;
	}

	#region IRequestHandler<GetRussiaCurrenciesQuery,CurrenciesVm> Members
	public async Task<CurrenciesVm> Handle(GetRussiaCurrenciesQuery request, CancellationToken cancellationToken)
	{
		var centralBank = await _centralBankRepository.GetCentralBankAsync(Countries.Russia, cancellationToken);
		return new CurrenciesVm(centralBank.Currencies.Select(x => _mapper.Map<CurrencyDto>(x)).ToList());
	}
	#endregion

}