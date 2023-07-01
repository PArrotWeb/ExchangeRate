using System.Text;
using System.Text.Json;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Persistence.CentralBanksApi.Deserializers;

public abstract class JsonCentralBankDeserializer<TParsingModel> : CentralBankDeserializer
{

	public override async Task<List<Currency>> DeserializeAsync(string data, CancellationToken cancellationToken)
	{
		// deserialize async json by parsing model. Stream from data
		using var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
		var parsedData = await JsonSerializer.DeserializeAsync<TParsingModel>(stream, cancellationToken: cancellationToken);

		// check if parsed data is null
		if (parsedData is null)
		{
			throw new InvalidOperationException("Json parsing data is null");
		}
		
		// map parsed data to currencies
		var currencies = await MapToCurrenciesAsync(parsedData, cancellationToken);
		
		return currencies;
	}
	
	protected abstract Task<List<Currency>> MapToCurrenciesAsync(TParsingModel parsedData, CancellationToken cancellationToken);
}