using System.Xml.Serialization;
using ExchangeRate.Persistence.CentralBanksApi.Russia.Deserializing.ParsingModels;

namespace ExchangeRate.Persistence.CentralBanksApi.Deserializers;

public abstract class XmlCentralBankDeserializer<TParsingModel> : BaseCentralBankDeserializer<TParsingModel>
{
	protected override async Task<TParsingModel> ParseByModel(string data, CancellationToken cancellationToken)
	{
		var serializer = new XmlSerializer(typeof(ValCurs));
		using var reader = new StringReader(data);
		var parsedData = await Task.Run(() => (TParsingModel)serializer.Deserialize(reader)!, cancellationToken);
		return parsedData;
	}
}