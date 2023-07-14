using System.Text;
using System.Text.Json;
using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Persistence.CentralBanksApi.Deserializers;

/// <summary>
/// Base class for json deserializing central bank api data
/// </summary>
/// <typeparam name="TParsingModel"></typeparam>
public abstract class JsonCentralBankDeserializer<TParsingModel> : CentralBankDeserializer
{
	/// <summary>
	/// Deserialize string data from api to list of currencies
	/// </summary>
	/// <param name="data">string from json</param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="InvalidOperationException"></exception>
	public override async Task<List<Currency>> DeserializeAsync(string data, CancellationToken cancellationToken)
	{
		// deserialize async json by parsing model. Stream from data
		using var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
		var parsedData =
			await JsonSerializer.DeserializeAsync<TParsingModel>(stream, cancellationToken: cancellationToken);

		// check if parsed data is null
		if (parsedData is null)
		{
			throw new InvalidOperationException("Json parsing data is null");
		}

		// map parsed data to currencies
		var currencies = await MapToCurrenciesAsync(parsedData, cancellationToken);

		return currencies;
	}

	/// <summary>
	/// Map parsed data to currencies
	/// </summary>
	/// <param name="parsedData">Data deserialized to TParsingModel</param>
	/// <param name="cancellationToken"></param>
	/// <returns>List of currencies</returns>
	protected abstract Task<List<Currency>> MapToCurrenciesAsync(TParsingModel parsedData,
		CancellationToken cancellationToken);
}