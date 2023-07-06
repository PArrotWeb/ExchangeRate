using ExchangeRate.Application.Common.Converter;
using ExchangeRate.Application.Interfaces;
using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Convert;

public sealed class GetConvertedCurrencyQueryHandler : IRequestHandler<GetConvertedCurrencyQuery, ConvertDto>
{
	private readonly ICentralBankRepository _centralBankRepository;

	public GetConvertedCurrencyQueryHandler(ICentralBankRepository centralBankRepository)
	{
		_centralBankRepository = centralBankRepository;
	}

	#region IRequestHandler<GetConvertedCurrencyQuery,ConvertDto> Members
	public async Task<ConvertDto> Handle(GetConvertedCurrencyQuery request, CancellationToken cancellationToken)
	{
		var repository = await _centralBankRepository.GetCentralBankAsync(request.Country, cancellationToken);

		var currencyFrom = await Task.Run(
			() => repository.Currencies.FirstOrDefault(x => x?.CharCode == request.FromCharCode, null),
			cancellationToken);

		var currencyTo = await Task.Run(
			() => repository.Currencies.FirstOrDefault(x => x?.CharCode == request.ToCharCode, null),
			cancellationToken);

		if (currencyFrom is null || currencyTo is null)
		{
			throw new Exception("Currency not found");
		}

		var amount = CurrencyConverter.Convert(currencyFrom, currencyTo, request.Amount);

		var dto = new ConvertDto
		{
			Amount = amount
		};

		return dto;
	}
	#endregion

}