using ExchangeRate.Application.Common.Converter;
using ExchangeRate.Application.Interfaces;
using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Convert;

/// <summary>
/// Query handler for convert request
/// </summary>
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
		// Get central bank by country name
		var repository = await _centralBankRepository.GetCentralBankAsync(request.Country, cancellationToken);

		// Get currencies by char codes
		var currencyFrom = await Task.Run(
			() => repository.Currencies.FirstOrDefault(x => x?.CharCode == request.FromCharCode, null),
			cancellationToken);

		var currencyTo = await Task.Run(
			() => repository.Currencies.FirstOrDefault(x => x?.CharCode == request.ToCharCode, null),
			cancellationToken);

		// Check if currencies are not null
		if (currencyFrom is null || currencyTo is null)
		{
			throw new Exception("Currency not found");
		}

		// Convert
		var amount = CurrencyConverter.Convert(currencyFrom, currencyTo, request.Amount);

		// Return ConvertDto with converted amount
		var dto = new ConvertDto
		{
			Amount = amount
		};

		return dto;
	}
	#endregion

}