using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi.Exceptions;

namespace ExchangeRate.Persistence.CentralBanksApi.Deserializers;

public abstract class BaseCentralBankDeserializer<TParsingModel> : ICentralBankDeserializer
{

	#region ICentralBankDeserializer Members
	public async Task<List<Currency>> DeserializeAsync(string data, CancellationToken cancellationToken)
	{
		// parse
		var parsedData = await ParseByModel(data, cancellationToken);

		// check parse result
		if (parsedData == null)
		{
			throw new ApiParseErrorException("Can't parse data from API");
		}

		// map parsedData to domain model
		var currencies = await MapToDomainModel(parsedData, cancellationToken);

		return currencies;
	}
	#endregion

	protected abstract Task<TParsingModel> ParseByModel(string data, CancellationToken cancellationToken);

	protected abstract Task<List<Currency>> MapToDomainModel(TParsingModel parsedData,
		CancellationToken cancellationToken);
}