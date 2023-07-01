using System.Xml.Serialization;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Persistence.CentralBanksApi.Deserializers;

public abstract class XmlCentralBankDeserializer<TParsingModel> : CentralBankDeserializer
{

	public override async Task<List<Currency>> DeserializeAsync(string data, CancellationToken cancellationToken)
	{
		// deserialize xml by parsing model
		var serializer = new XmlSerializer(typeof(TParsingModel));
		using var reader = new StringReader(data);
		var parsedData = await Task.Run(() => (TParsingModel)serializer.Deserialize(reader)!, cancellationToken);
		
		// check if parsed data is null
		if (parsedData is null)
		{
			throw new InvalidOperationException("Xml parsing data is null");
		}
		
		// map parsed data to currencies
		var currencies = await MapToCurrenciesAsync(parsedData, cancellationToken);
		
		return currencies;
	}
	
	protected abstract Task<List<Currency>> MapToCurrenciesAsync(TParsingModel parsedData, CancellationToken cancellationToken);
}